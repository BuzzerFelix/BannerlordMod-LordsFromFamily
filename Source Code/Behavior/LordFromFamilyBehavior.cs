using System;
using SueLordFromFamily.dialogue;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace SueLordFromFamily.Behavior
{
	// Token: 0x02000015 RID: 21
	internal class LordFromFamilyBehavior : CampaignBehaviorBase
	{
		// Token: 0x060000B9 RID: 185 RVA: 0x0000527A File Offset: 0x0000347A
		public override void RegisterEvents()
		{
			CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, new Action<CampaignGameStarter>(this.OnSessionLaunched));
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00002D81 File Offset: 0x00000F81
		public override void SyncData(IDataStore dataStore)
		{
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000529F File Offset: 0x0000349F
		public void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
		{
			new ChaneHeroClanDialogue(campaignGameStarter).GenerateDialogue();
			new CreateClanDialogue(campaignGameStarter).GenerateDialogue();
			InformationManager.DisplayMessage(new InformationMessage("LordFromFamily OnSessionLaunched"));
		}
	}
}
