using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace SueLordFromFamily.dialogue
{
	// Token: 0x02000011 RID: 17
	internal class CreateClanDialogue : AbsCreateDialogue
	{
		// Token: 0x0600008F RID: 143 RVA: 0x00004370 File Offset: 0x00002570
		public CreateClanDialogue(CampaignGameStarter campaignGameStarter) : base(campaignGameStarter)
		{
			this.clanCreateBussniess = new ClanCreateBussniess();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00004388 File Offset: 0x00002588
		public override void GenerateDialogue()
		{
			new DialogueCreator().IsPlayer(true).Id("sue_clan_create_from_family").InputOrder("hero_main_options").OutOrder("sue_clan_create_from_family_request").Text(base.LoactionText("sue_clan_create_from_family_request")).Condition(new DialogueCreator.ConditionDelegate(this.CreateClanCondition)).CreateAndAdd(base.CampaignGameStarter);
			new DialogueCreator().IsPlayer(false).Id("sue_clan_create_from_family").InputOrder("sue_clan_create_from_family_request").OutOrder("sue_clan_create_from_family_start").Text(base.LoactionText("sue_clan_create_from_family_choice_settlement_tip")).CreateAndAdd(base.CampaignGameStarter);
			new DialogueCreator().IsPlayer(false).Id("sue_clan_create_from_family_need_spouse").InputOrder("sue_clan_create_from_family_choice_other").OutOrder("sue_clan_create_from_family_take_spouse").Text(base.LoactionText("sue_clan_create_from_family_need_spouse")).Condition(new DialogueCreator.ConditionDelegate(this.NeedSpouse)).CreateAndAdd(base.CampaignGameStarter);
			new DialogueCreator().IsPlayer(false).Id("sue_clan_create_from_family_need_money").InputOrder("sue_clan_create_from_family_choice_other").OutOrder("sue_clan_create_from_family_take_money").Text(base.LoactionText("sue_clan_create_from_family_need_money")).Condition(new DialogueCreator.ConditionDelegate(this.NeedNotSpouse)).Result(new DialogueCreator.ResultDelegate(this.NeedNotSpouseResult)).CreateAndAdd(base.CampaignGameStarter);
			new DialogueCreator().IsPlayer(false).Id("sue_clan_create_from_family_need_money").InputOrder("sue_clan_create_from_family_request_money").OutOrder("sue_clan_create_from_family_take_money").Text(base.LoactionText("sue_clan_create_from_family_need_money")).CreateAndAdd(base.CampaignGameStarter);
			new DialogueCreator().IsPlayer(false).Id("sue_clan_create_from_family_request_children").InputOrder("sue_clan_create_from_family_complete_take_money").OutOrder("sue_clan_create_from_family_request_children_out").Condition(new DialogueCreator.ConditionDelegate(this.HasChildren)).Text(base.LoactionText("sue_clan_create_from_family_vassal_request_children")).CreateAndAdd(base.CampaignGameStarter);
			new DialogueCreator().IsPlayer(false).Id("sue_clan_create_from_family_request_complete_no_children").InputOrder("sue_clan_create_from_family_complete_take_money").OutOrder("sue_clan_create_from_family_complete_2").Text(base.LoactionText("sue_clan_create_from_family_complete")).Condition(new DialogueCreator.ConditionDelegate(this.HasNoChildren)).Result(new DialogueCreator.ResultDelegate(this.CreateVassal)).CreateAndAdd(base.CampaignGameStarter);
			new DialogueCreator().IsPlayer(true).Id("sue_clan_create_from_family_request_children_result_1").InputOrder("sue_clan_create_from_family_request_children_out").OutOrder("sue_clan_create_from_family_complete").Text(base.LoactionText("sue_clan_create_from_family_vassal_request_children_result_1")).Result(new DialogueCreator.ResultDelegate(this.TogetherWithThireChildren)).CreateAndAdd(base.CampaignGameStarter);
			new DialogueCreator().IsPlayer(true).Id("sue_clan_create_from_family_request_children_result_2").InputOrder("sue_clan_create_from_family_request_children_out").OutOrder("sue_clan_create_from_family_complete").Text(base.LoactionText("sue_clan_create_from_family_vassal_request_children_result_2")).CreateAndAdd(base.CampaignGameStarter);
			new DialogueCreator().IsPlayer(true).Id("sue_clan_create_from_family_money_close").InputOrder("sue_clan_create_from_family_request_children_out").OutOrder("close_window").Text(base.LoactionText("sue_clan_create_from_family_of_forget")).CreateAndAdd(base.CampaignGameStarter);
			new DialogueCreator().IsPlayer(false).Id("sue_clan_create_from_family_request_complete").InputOrder("sue_clan_create_from_family_complete").OutOrder("sue_clan_create_from_family_complete_2").Text(base.LoactionText("sue_clan_create_from_family_complete")).Result(new DialogueCreator.ResultDelegate(this.CreateVassal)).CreateAndAdd(base.CampaignGameStarter);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004728 File Offset: 0x00002928
		private bool CreateClanCondition()
		{
			bool flag = Hero.OneToOneConversationHero == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				List<Settlement> list = Enumerable.ToList<Settlement>(Enumerable.Where<Settlement>(Hero.MainHero.Clan.Settlements, (Settlement settlement) => settlement.IsTown || settlement.IsCastle));
				bool flag2 = list.Count < 1;
				if (flag2)
				{
					result = false;
				}
				else
				{
					Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
					bool flag3 = oneToOneConversationHero != null && oneToOneConversationHero.Clan == Clan.PlayerClan && oneToOneConversationHero.PartyBelongedTo != null && oneToOneConversationHero.PartyBelongedTo.LeaderHero == Hero.MainHero && Hero.MainHero.MapFaction is Kingdom && !Hero.MainHero.ExSpouses.Contains(oneToOneConversationHero) && oneToOneConversationHero != Hero.MainHero.Spouse;
					if (flag3)
					{
						Kingdom kingdom = Hero.MainHero.MapFaction as Kingdom;
						bool flag4 = ((kingdom != null) ? kingdom.Ruler : null) == Hero.MainHero;
						if (flag4)
						{
							bool flag5 = Hero.MainHero.Clan.Gold >= 50000;
							bool flag6 = flag5;
							if (flag6)
							{
								this.ResetDataForCreateClan();
							}
							return flag5;
						}
					}
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000486A File Offset: 0x00002A6A
		private void CreateVassal()
		{
			this.clanCreateBussniess.CreateVassal();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000487C File Offset: 0x00002A7C
		private void ShowSelectSettlement()
		{
			List<Settlement> list = Enumerable.ToList<Settlement>(Enumerable.Where<Settlement>(Hero.MainHero.Clan.Settlements, (Settlement settlement) => settlement.IsTown || settlement.IsCastle));
			int num = 10;
			bool flag = Enumerable.Count<Settlement>(list) <= num;
			if (flag)
			{
				list.ForEach(delegate(Settlement settlement)
				{
					this.addPlayerLineToSelectSettlement(settlement);
				});
				base.CampaignGameStarter.AddRepeatablePlayerLine(CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_SETTLEMENT_ITEM, "sue_clan_create_from_family_start", "close_window", GameTexts.FindText("sue_clan_create_from_family_of_forget", null).ToString(), null, null, 100, null);
			}
			else
			{
				List<int> canAddIndexs = RandomUtils.RandomNumbers(num, 0, Enumerable.Count<Settlement>(list), new List<int>());
				int index = 0;
				list.ForEach(delegate(Settlement settlement)
				{
					int index9;
					bool flag2 = canAddIndexs.Contains(index);
					if (flag2)
					{
						this.addPlayerLineToSelectSettlement(settlement);
					}
					index9 = index;
					index++;
				});
				base.CampaignGameStarter.AddRepeatablePlayerLine(CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_SETTLEMENT_ITEM, "sue_clan_create_from_family_start", "sue_clan_create_from_family_take_settlement_change", GameTexts.FindText("sue_clan_create_from_family_choice_spouse_item_change", null).ToString(), null, delegate()
				{
					this.GenerateDataForCreateClan();
				}, 100, null);
				base.CampaignGameStarter.AddDialogLine(CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_SETTLEMENT_ITEM, "sue_clan_create_from_family_take_settlement_change", "sue_clan_create_from_family_start", GameTexts.FindText("sue_clan_create_from_family_choice_spouse_item_change_tip", null).ToString(), null, null, 100, null);
				base.CampaignGameStarter.AddRepeatablePlayerLine(CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_SETTLEMENT_ITEM, "sue_clan_create_from_family_start", "close_window", GameTexts.FindText("sue_clan_create_from_family_of_forget", null).ToString(), null, null, 100, null);
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000049FC File Offset: 0x00002BFC
		private void ShowSelectSpouseList()
		{
			IEnumerable<TroopRosterElement> enumerable = Enumerable.Where<TroopRosterElement>(MobileParty.MainParty.MemberRoster.GetTroopRoster(), (TroopRosterElement obj) => obj.Character.IsHero && obj.Character.HeroObject.Spouse == null && obj.Character.HeroObject.IsPlayerCompanion);
			int num = 10;
			bool flag = Enumerable.Count<TroopRosterElement>(enumerable) <= num;
			if (flag)
			{
				Enumerable.ToList<TroopRosterElement>(enumerable).ForEach(delegate(TroopRosterElement obj)
				{
					Hero heroObject = obj.Character.HeroObject;
					this.addPlayerLineToSelectSpouse(heroObject);
				});
				base.CampaignGameStarter.AddRepeatablePlayerLine(CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_SPOUSE_ITEM, "sue_clan_create_from_family_take_spouse", "sue_clan_create_from_family_request_money", GameTexts.FindText("sue_clan_create_from_family_need_spouse_not", null).ToString(), null, null, 100, null);
				base.CampaignGameStarter.AddRepeatablePlayerLine(CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_SPOUSE_ITEM, "sue_clan_create_from_family_take_spouse", "close_window", GameTexts.FindText("sue_clan_create_from_family_of_forget", null).ToString(), null, null, 100, null);
			}
			else
			{
				Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
				List<CharacterObject> list = new List<CharacterObject>();
				foreach (TroopRosterElement troopRosterElement in enumerable)
				{
					list.Add(troopRosterElement.Character);
				}
				int item = list.IndexOf(oneToOneConversationHero.CharacterObject);
				List<int> canAddIndexs = RandomUtils.RandomNumbers(num, 0, Enumerable.Count<CharacterObject>(list), new List<int>
				{
					item
				});
				int index = 0;
				list.ForEach(delegate(CharacterObject obj)
				{
					Hero heroObject = obj.HeroObject;
					int index9;
					bool flag2 = canAddIndexs.Contains(index);
					if (flag2)
					{
						this.addPlayerLineToSelectSpouse(heroObject);
					}
					index9 = index;
					index++;
				});
				base.CampaignGameStarter.AddRepeatablePlayerLine(CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_SPOUSE_ITEM, "sue_clan_create_from_family_take_spouse", "sue_clan_create_from_family_take_spouse_change", GameTexts.FindText("sue_clan_create_from_family_choice_spouse_item_change", null).ToString(), null, delegate()
				{
					this.GenerateDataForCreateClan();
				}, 100, null);
				base.CampaignGameStarter.AddDialogLine(CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_SPOUSE_ITEM, "sue_clan_create_from_family_take_spouse_change", "sue_clan_create_from_family_take_spouse", GameTexts.FindText("sue_clan_create_from_family_choice_spouse_item_change_tip", null).ToString(), null, null, 100, null);
				base.CampaignGameStarter.AddRepeatablePlayerLine(CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_SPOUSE_ITEM, "sue_clan_create_from_family_take_spouse", "sue_clan_create_from_family_request_money", GameTexts.FindText("sue_clan_create_from_family_need_spouse_not", null).ToString(), null, null, 100, null);
				base.CampaignGameStarter.AddRepeatablePlayerLine(CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_SPOUSE_ITEM, "sue_clan_create_from_family_take_spouse", "close_window", GameTexts.FindText("sue_clan_create_from_family_of_forget", null).ToString(), null, delegate()
				{
				}, 100, null);
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00004C70 File Offset: 0x00002E70
		private void ShowClanMoneyTierList()
		{
			int num = 6;
			for (int i = 2; i < 7; i++)
			{
				bool flag = this.PlayGetMoneyByTierCondition(i);
				bool flag2 = !flag;
				if (flag2)
				{
					num = i - 1;
					break;
				}
			}
			for (int j = 2; j <= num; j++)
			{
				this.addPlayerLineToSelectClanMoneyTier(j);
			}
			base.CampaignGameStarter.AddRepeatablePlayerLine(CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_CLAN_MONEY_TIER_ITEM, "sue_clan_create_from_family_take_money", "close_window", GameTexts.FindText("sue_clan_create_from_family_of_forget", null).ToString(), null, null, 100, null);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00004D00 File Offset: 0x00002F00
		public bool HasNoChildren()
		{
			return !this.HasChildren();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00004D1C File Offset: 0x00002F1C
		public bool HasChildren()
		{
			bool result = false;
			Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
			bool flag = oneToOneConversationHero.Children.Count > 0;
			if (flag)
			{
				oneToOneConversationHero.Children.ForEach(delegate(Hero child)
				{
					bool flag2 = child.Clan == Clan.PlayerClan;
					if (flag2)
					{
						result = true;
					}
				});
			}
			return result;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00004D73 File Offset: 0x00002F73
		public void TogetherWithThireChildren()
		{
			this.clanCreateBussniess.isTogetherWithThireChildren = true;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004D82 File Offset: 0x00002F82
		private void ResetDataForCreateClan()
		{
			this.clanCreateBussniess.reset();
			this.GenerateDataForCreateClan();
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00004D98 File Offset: 0x00002F98
		private bool NeedSpouse()
		{
			return !this.NeedNotSpouse();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00004DB4 File Offset: 0x00002FB4
		private bool NeedNotSpouse()
		{
			Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
			return oneToOneConversationHero != null && oneToOneConversationHero.Spouse != null && oneToOneConversationHero.Spouse.Clan == Clan.PlayerClan;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00004DF0 File Offset: 0x00002FF0
		public void NeedNotSpouseResult()
		{
			Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
			bool flag = oneToOneConversationHero != null && oneToOneConversationHero.Spouse != null && oneToOneConversationHero.Spouse != Hero.MainHero && !Hero.MainHero.ExSpouses.Contains(oneToOneConversationHero.Spouse);
			if (flag)
			{
				bool flag2 = oneToOneConversationHero.Spouse.Clan == Clan.PlayerClan;
				if (flag2)
				{
					this.clanCreateBussniess.targetSpouse = oneToOneConversationHero.Spouse;
				}
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00004E68 File Offset: 0x00003068
		public bool PlayGetMoneyByTierCondition(int tier)
		{
			int num = this.clanCreateBussniess.TakeMoneyByTier(tier);
			return Hero.MainHero.Clan.Gold >= num;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00004EA7 File Offset: 0x000030A7
		public void PlayerGetMoneyByTierResult(int tier)
		{
			this.clanCreateBussniess.selectClanTier = tier;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00004EB8 File Offset: 0x000030B8
		private void GenerateDataForCreateClan()
		{
			PlayerLineUtils.cleanRepeatableLine(base.CampaignGameStarter, CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_SETTLEMENT_ITEM);
			PlayerLineUtils.cleanRepeatableLine(base.CampaignGameStarter, CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_SPOUSE_ITEM);
			PlayerLineUtils.cleanRepeatableLine(base.CampaignGameStarter, CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_CLAN_MONEY_TIER_ITEM);
			this.ShowSelectSettlement();
			this.ShowSelectSpouseList();
			this.ShowClanMoneyTierList();
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00004F10 File Offset: 0x00003110
		private void addPlayerLineToSelectSpouse(Hero spouse)
		{
			base.CampaignGameStarter.AddRepeatablePlayerLine(CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_SPOUSE_ITEM, "sue_clan_create_from_family_take_spouse", "sue_clan_create_from_family_request_money", spouse.Name.ToString(), delegate()
			{
				Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
				return oneToOneConversationHero != spouse;
			}, delegate()
			{
				this.clanCreateBussniess.targetSpouse = spouse;
			}, 100, null);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00004F78 File Offset: 0x00003178
		private void addPlayerLineToSelectSettlement(Settlement settlement)
		{
			base.CampaignGameStarter.AddRepeatablePlayerLine(CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_SETTLEMENT_ITEM, "sue_clan_create_from_family_start", "sue_clan_create_from_family_choice_other", settlement.Name.ToString(), null, delegate()
			{
				this.clanCreateBussniess.targetSettlement = settlement;
			}, 100, null);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00004FD8 File Offset: 0x000031D8
		private void addPlayerLineToSelectClanMoneyTier(int tier)
		{
			base.CampaignGameStarter.AddRepeatablePlayerLine(CreateClanDialogue.FLAG_CLAN_CREATE_CHOICE_CLAN_MONEY_TIER_ITEM, "sue_clan_create_from_family_take_money", "sue_clan_create_from_family_complete_take_money", string.Format("{0} GLOD ( Tier = {1} )", this.clanCreateBussniess.TakeMoneyByTier(tier), tier), null, delegate()
			{
				this.clanCreateBussniess.selectClanTier = tier;
			}, 100, null);
		}

		// Token: 0x04000034 RID: 52
		public static string FLAG_CLAN_CREATE_CHOICE_SETTLEMENT_ITEM = "sue_clan_create_from_family_choice_settlememt_item";

		// Token: 0x04000035 RID: 53
		public static string FLAG_CLAN_CREATE_CHOICE_SPOUSE_ITEM = "sue_clan_create_from_family_choice_settlememt_item";

		// Token: 0x04000036 RID: 54
		public static string FLAG_CLAN_CREATE_CHOICE_CLAN_MONEY_TIER_ITEM = "sue_clan_create_from_family_choice_clan_money_tier";

		// Token: 0x04000037 RID: 55
		private ClanCreateBussniess clanCreateBussniess;
	}
}
