using System;
using HarmonyLib;
using SueLordFromFamily.Behavior;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SueLordFromFamily
{
	// Token: 0x02000007 RID: 7
	public class SubModule : MBSubModuleBase
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00002550 File Offset: 0x00000750
		protected override void OnSubModuleLoad()
		{
			Harmony harmony = new Harmony("mod.sue.lordFromFamily");
			harmony.PatchAll();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002570 File Offset: 0x00000770
		protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
		{
			InformationManager.DisplayMessage(new InformationMessage("LordFromFamily OnGameStart"));
			bool flag = gameStarterObject.GetType() == typeof(CampaignGameStarter);
			if (flag)
			{
				((CampaignGameStarter)gameStarterObject).AddBehavior(new LordFromFamilyBehavior());
				((CampaignGameStarter)gameStarterObject).LoadGameTexts(string.Format("{0}/Modules/{1}/ModuleData/sue_clan_create_from_family.xml", BasePath.Name, "SueLordFromFamily"));
			}
		}
	}
}
