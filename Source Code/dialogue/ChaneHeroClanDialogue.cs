using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace SueLordFromFamily.dialogue
{
	// Token: 0x02000010 RID: 16
	public class ChaneHeroClanDialogue : AbsCreateDialogue
	{
		// Token: 0x06000085 RID: 133 RVA: 0x00003F0A File Offset: 0x0000210A
		public ChaneHeroClanDialogue(CampaignGameStarter campaignGameStarter) : base(campaignGameStarter)
		{
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003F18 File Offset: 0x00002118
		public override void GenerateDialogue()
		{
			new DialogueCreator().IsPlayer(true).Id("sue_clan_create_from_family_change_clan").InputOrder("hero_main_options").OutOrder("sue_clan_create_from_family_change_clan_request").Text(base.LoactionText("sue_clan_create_from_family_change_clan_request")).Condition(new DialogueCreator.ConditionDelegate(this.ChangeClanCondition)).CreateAndAdd(base.CampaignGameStarter);
			new DialogueCreator().IsPlayer(false).Id("sue_clan_create_from_family_change_clan_answer").InputOrder("sue_clan_create_from_family_change_clan_request").OutOrder("sue_clan_create_from_family_change_clan_answer_select").Text(base.LoactionText("sue_clan_create_from_family_change_clan_answer")).CreateAndAdd(base.CampaignGameStarter);
			new DialogueCreator().IsPlayer(false).Id("sue_clan_create_from_family_change_clan_complete").InputOrder("sue_clan_create_from_family_change_clan_answer_select_result").OutOrder("sue_clan_create_from_family_complete_2").Text(base.LoactionText("sue_clan_create_from_family_complete")).Result(new DialogueCreator.ResultDelegate(this.ChangeHeroToOtherClan)).CreateAndAdd(base.CampaignGameStarter);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00004018 File Offset: 0x00002218
		private void GenerateDialogueForSelectClan()
		{
			PlayerLineUtils.cleanRepeatableLine(base.CampaignGameStarter, ChaneHeroClanDialogue.FLAG_CLAN_CREATE_CHOICE_CLAN_ITEM);
			Kingdom kingdom = Hero.MainHero.MapFaction as Kingdom;
			List<Clan> list = Enumerable.ToList<Clan>(Enumerable.Where<Clan>(kingdom.Clans, (Clan clan) => clan != Clan.PlayerClan));
			int num = 10;
			bool flag = Enumerable.Count<Clan>(list) <= num;
			if (flag)
			{
				list.ForEach(delegate(Clan clan)
				{
					this.addPlayerLineToSelectClan(clan);
				});
				base.CampaignGameStarter.AddRepeatablePlayerLine(ChaneHeroClanDialogue.FLAG_CLAN_CREATE_CHOICE_CLAN_ITEM, "sue_clan_create_from_family_change_clan_answer_select", "close_window", GameTexts.FindText("sue_clan_create_from_family_of_forget", null).ToString(), null, null, 100, null);
			}
			else
			{
				List<int> canAddIndexs = RandomUtils.RandomNumbers(num, 0, Enumerable.Count<Clan>(list), new List<int>());
				int index = 0;
				list.ForEach(delegate(Clan clan)
				{
					int index;
					bool flag2 = canAddIndexs.Contains(index);
					if (flag2)
					{
						this.addPlayerLineToSelectClan(clan);
					}
					index = index;
					index++;
				});
				base.CampaignGameStarter.AddRepeatablePlayerLine(ChaneHeroClanDialogue.FLAG_CLAN_CREATE_CHOICE_CLAN_ITEM, "sue_clan_create_from_family_change_clan_answer_select", "sue_clan_create_from_family_take_clan_change", GameTexts.FindText("sue_clan_create_from_family_choice_spouse_item_change", null).ToString(), null, delegate()
				{
					this.GenerateDialogueForSelectClan();
				}, 100, null);
				base.CampaignGameStarter.AddDialogLine(ChaneHeroClanDialogue.FLAG_CLAN_CREATE_CHOICE_CLAN_ITEM, "sue_clan_create_from_family_take_clan_change", "sue_clan_create_from_family_change_clan_answer_select", GameTexts.FindText("sue_clan_create_from_family_choice_spouse_item_change_tip", null).ToString(), null, null, 100, null);
				base.CampaignGameStarter.AddRepeatablePlayerLine(ChaneHeroClanDialogue.FLAG_CLAN_CREATE_CHOICE_CLAN_ITEM, "sue_clan_create_from_family_change_clan_answer_select", "close_window", GameTexts.FindText("sue_clan_create_from_family_of_forget", null).ToString(), null, null, 100, null);
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000041B8 File Offset: 0x000023B8
		private void addPlayerLineToSelectClan(Clan clan)
		{
			int num = Enumerable.Count<bool>(Enumerable.Select<Hero, bool>(clan.Heroes, (Hero obj) => (int)obj.Age >= Campaign.Current.Models.AgeModel.HeroComesOfAge));
			string text = clan.Name.ToString() + string.Format("   ( Hero Count = {0};  Clan Tier = {1} )", num, clan.Tier);
			base.CampaignGameStarter.AddRepeatablePlayerLine(ChaneHeroClanDialogue.FLAG_CLAN_CREATE_CHOICE_CLAN_ITEM, "sue_clan_create_from_family_change_clan_answer_select", "sue_clan_create_from_family_change_clan_answer_select_result", text, null, delegate()
			{
				this.targetChangeClan = clan;
			}, 100, null);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00004274 File Offset: 0x00002474
		private bool ChangeClanCondition()
		{
			Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
			bool flag = oneToOneConversationHero == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = false;
				bool flag3 = oneToOneConversationHero.Clan == Clan.PlayerClan;
				if (flag3)
				{
					Kingdom kingdom = Hero.MainHero.MapFaction as Kingdom;
					bool flag4 = ((kingdom != null) ? kingdom.Ruler : null) == Hero.MainHero && kingdom.Clans.Count > 1;
					if (flag4)
					{
						this.ResetDataForChangeClan();
						flag2 = true;
					}
				}
				result = flag2;
			}
			return result;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000042F9 File Offset: 0x000024F9
		private void ResetDataForChangeClan()
		{
			this.targetChangeClan = null;
			this.GenerateDialogueForSelectClan();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000430C File Offset: 0x0000250C
		private void ChangeHeroToOtherClan()
		{
			Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
			bool flag = this.targetChangeClan != null;
			if (flag)
			{
				HeroOperation.NewClanAllocateForHero(oneToOneConversationHero, this.targetChangeClan);
			}
			else
			{
				InformationManager.DisplayMessage(new InformationMessage("LordFromFamily error occurred, cant change the hero to other clan!"));
			}
		}

		// Token: 0x04000032 RID: 50
		public static string FLAG_CLAN_CREATE_CHOICE_CLAN_ITEM = "sue_clan_create_from_family_choice_clan_item";

		// Token: 0x04000033 RID: 51
		private Clan targetChangeClan;
	}
}
