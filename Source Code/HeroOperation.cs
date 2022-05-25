using System;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.Core;

namespace SueLordFromFamily
{
	// Token: 0x02000003 RID: 3
	internal class HeroOperation
	{
		// Token: 0x06000003 RID: 3 RVA: 0x0000216C File Offset: 0x0000036C
		public static void NewClanAllocateForHero(Hero hero, Clan clan)
		{
			bool flag = hero.Clan == Clan.PlayerClan;
			if (flag)
			{
				HeroOperation.DealApplyByFire(Hero.MainHero.Clan, hero);
				HeroOperation.SetOccupationToLord(hero);
				hero.Clan = clan;
				hero.CompanionOf = null;
				hero.ChangeState(1);
				hero.IsNoble = true;
				bool flag2 = hero.Age >= (float)Campaign.Current.Models.AgeModel.HeroComesOfAge && hero.PartyBelongedTo == null;
				if (flag2)
				{
					MobileParty mobileParty = clan.CreateNewMobileParty(hero);
					mobileParty.ItemRoster.AddToCounts(DefaultItems.Grain, 10);
					mobileParty.ItemRoster.AddToCounts(DefaultItems.Meat, 5);
				}
				GiveGoldAction.ApplyBetweenCharacters(Hero.MainHero, hero, 2000, false);
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002238 File Offset: 0x00000438
		public static void SetOccupationToLord(Hero hero)
		{
			bool flag = hero.CharacterObject.Occupation = 2;
			if (!flag)
			{
				FieldInfo field = hero.CharacterObject.GetType().GetField("_originCharacter", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				PropertyInfo property = typeof(CharacterObject).GetProperty("Occupation");
				bool flag2 = null != property && null != property.DeclaringType;
				if (flag2)
				{
					property = property.DeclaringType.GetProperty("Occupation");
					bool flag3 = null != property;
					if (flag3)
					{
						property.SetValue(hero.CharacterObject, 2, null);
					}
				}
				bool flag4 = null != field;
				if (flag4)
				{
					field.SetValue(hero.CharacterObject, CharacterObject.PlayerCharacter);
				}
				else
				{
					FieldInfo field2 = hero.CharacterObject.GetType().GetField("_originCharacterStringId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					bool flag5 = null != field2;
					if (flag5)
					{
						field2.SetValue(hero.CharacterObject, CharacterObject.PlayerCharacter.StringId);
					}
				}
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002344 File Offset: 0x00000544
		public static void DealApplyByFire(Clan clan, Hero hero)
		{
			bool flag = hero.LastSeenPlace == null;
			if (flag)
			{
				hero.CacheLastSeenInformation(hero.HomeSettlement, true);
				hero.SyncLastSeenInformation();
			}
			RemoveCompanionAction.ApplyByFire(Hero.MainHero.Clan, hero);
		}
	}
}
