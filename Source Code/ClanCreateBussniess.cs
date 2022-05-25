using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;
using static TaleWorlds.CampaignSystem.Hero;

namespace SueLordFromFamily
{
	// Token: 0x02000008 RID: 8
	internal class ClanCreateBussniess
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000019 RID: 25 RVA: 0x000025EC File Offset: 0x000007EC
		// (set) Token: 0x06000018 RID: 24 RVA: 0x000025E3 File Offset: 0x000007E3
		public Hero targetSpouse { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000025FD File Offset: 0x000007FD
		// (set) Token: 0x0600001A RID: 26 RVA: 0x000025F4 File Offset: 0x000007F4
		public Settlement targetSettlement { get; set; }

		// Token: 0x0600001C RID: 28 RVA: 0x00002605 File Offset: 0x00000805
		public void reset()
		{
			this.targetSpouse = null;
			this.targetSettlement = null;
			this.isTogetherWithThireChildren = false;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002620 File Offset: 0x00000820
		public void CreateVassal()
		{
			bool flag = this.targetSettlement == null;
			if (!flag)
			{
				Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
				bool flag2 = oneToOneConversationHero == null;
				if (!flag2)
				{
					Kingdom kingdom = Hero.MainHero.MapFaction as Kingdom;
					bool flag3 = kingdom == null;
					if (!flag3)
					{
						CultureObject culture = this.targetSettlement.Culture;
						TextObject textObject = NameGenerator.Current.GenerateClanName(culture, this.targetSettlement);
						string str = Guid.NewGuid().ToString().Replace("-", "");
						bool flag4 = oneToOneConversationHero.LastSeenPlace == null;
						if (flag4)
						{
							oneToOneConversationHero.CacheLastSeenInformation(oneToOneConversationHero.HomeSettlement, true);
							oneToOneConversationHero.SyncLastSeenInformation();
						}
						HeroOperation.DealApplyByFire(Hero.MainHero.Clan, oneToOneConversationHero);
						HeroOperation.SetOccupationToLord(oneToOneConversationHero);
						oneToOneConversationHero.ChangeState((CharacterStates)1);
						Clan clan = MBObjectManager.Instance.CreateObject<Clan>("sue_clan_" + str);
						Banner banner = Banner.CreateRandomClanBanner(-1);
						clan.InitializeClan(textObject, textObject, culture, banner, default(Vec2), false);
						clan.SetLeader(oneToOneConversationHero);
						FieldInfo field = clan.GetType().GetField("_tier", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
						bool flag5 = null != field;
						if (flag5)
						{
							field.SetValue(clan, this.selectClanTier);
						}
						clan.AddRenown((float)(50 * this.selectClanTier), true);
						oneToOneConversationHero.Clan = clan;
						oneToOneConversationHero.CompanionOf = null;
						oneToOneConversationHero.IsNoble = true;
						oneToOneConversationHero.SetTraitLevelInternal(DefaultTraits.Commander, 1);
						MobileParty mobileParty = clan.CreateNewMobileParty(oneToOneConversationHero);
						mobileParty.ItemRoster.AddToCounts(DefaultItems.Grain, 10);
						mobileParty.ItemRoster.AddToCounts(DefaultItems.Meat, 5);
						ChangeOwnerOfSettlementAction.ApplyByKingDecision(oneToOneConversationHero, this.targetSettlement);
						clan.UpdateHomeSettlement(this.targetSettlement);
						int num = this.TakeMoneyByTier(this.selectClanTier);
						bool flag6 = this.targetSpouse != null;
						if (flag6)
						{
							GiveGoldAction.ApplyBetweenCharacters(Hero.MainHero, oneToOneConversationHero, num / 2, false);
						}
						else
						{
							GiveGoldAction.ApplyBetweenCharacters(Hero.MainHero, oneToOneConversationHero, num, false);
						}
						int num2 = this.ShipIncreateByTier(this.selectClanTier);
						ChangeRelationAction.ApplyPlayerRelation(oneToOneConversationHero, num2, true, true);
						bool flag7 = this.targetSpouse != null;
						if (flag7)
						{
							ChangeRelationAction.ApplyPlayerRelation(this.targetSpouse, num2, true, true);
						}
						int shipReduce = this.ShipReduceByTier(this.selectClanTier);
						Kingdom kingdom2 = Hero.MainHero.MapFaction as Kingdom;
						bool flag8 = kingdom2 != null && shipReduce > 0;
						if (flag8)
						{
							Enumerable.ToList<Clan>(kingdom2.Clans).ForEach(delegate(Clan obj)
							{
								bool flag11 = obj != Clan.PlayerClan;
								if (flag11)
								{
									ChangeRelationAction.ApplyPlayerRelation(obj.Leader, shipReduce * -1, true, true);
								}
							});
						}
						bool flag9 = this.targetSpouse != null;
						if (flag9)
						{
							this.targetSpouse.Spouse = oneToOneConversationHero;
							InformationManager.AddQuickInformation(new TextObject(string.Format("{0} marry with {1}", oneToOneConversationHero.Name, this.targetSpouse.Name), null), 0, null, "event:/ui/notification/quest_finished");
							HeroOperation.DealApplyByFire(Hero.MainHero.Clan, this.targetSpouse);
							this.targetSpouse.ChangeState((CharacterStates)1);
							this.targetSpouse.IsNoble = true;
							HeroOperation.SetOccupationToLord(this.targetSpouse);
							this.targetSpouse.CompanionOf = null;
							this.targetSpouse.Clan = clan;
							this.targetSpouse.SetTraitLevelInternal(DefaultTraits.Commander, 1);
							MobileParty mobileParty2 = clan.CreateNewMobileParty(this.targetSpouse);
							mobileParty2.ItemRoster.AddToCounts(DefaultItems.Grain, 10);
							mobileParty2.ItemRoster.AddToCounts(DefaultItems.Meat, 5);
							GiveGoldAction.ApplyBetweenCharacters(Hero.MainHero, this.targetSpouse, num / 2, false);
						}
						bool flag10 = this.isTogetherWithThireChildren;
						if (flag10)
						{
							this.DealTheirChildren(oneToOneConversationHero, clan);
						}
						ChangeKingdomAction.ApplyByJoinToKingdom(clan, kingdom, true);
					}
				}
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002A08 File Offset: 0x00000C08
		public int TakeMoneyByTier(int tier)
		{
			return (int)Math.Pow(5.0, (double)tier) * 1000;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002A34 File Offset: 0x00000C34
		public int ShipIncreateByTier(int tier)
		{
			return tier * 10;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002A4C File Offset: 0x00000C4C
		public int ShipReduceByTier(int tier)
		{
			int num = tier * 10;
			Kingdom kingdom = Hero.MainHero.MapFaction as Kingdom;
			bool flag = kingdom != null && kingdom.Clans.Count >= 3;
			if (flag)
			{
				num /= kingdom.Clans.Count - 1;
			}
			return num;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002AA4 File Offset: 0x00000CA4
		public void DealTheirChildren(Hero hero, Clan clan)
		{
			bool flag = hero.Children.Count > 0;
			if (flag)
			{
				hero.Children.ForEach(delegate(Hero chilredn)
				{
					HeroOperation.NewClanAllocateForHero(chilredn, clan);
					this.DealTheirChildren(chilredn, clan);
				});
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002AF4 File Offset: 0x00000CF4
		public static List<Settlement> GetCandidateSettlements()
		{
			Vec2 playerPosition = Hero.MainHero.PartyBelongedTo.Position2D;
			IEnumerable<Settlement> settlements = Hero.MainHero.Clan.Settlements;
			Func<Settlement, bool> func = (Settlement settlement) => settlement.IsTown || settlement.IsCastle;
			return Enumerable.ToList<Settlement>(Enumerable.OrderBy<Settlement, float>(Enumerable.Where<Settlement>(settlements, func), (Settlement n) => n.Position2D.Distance(playerPosition)));
		}

		// Token: 0x04000006 RID: 6
		public int selectClanTier = 2;

		// Token: 0x04000007 RID: 7
		public bool isTogetherWithThireChildren;
	}
}
