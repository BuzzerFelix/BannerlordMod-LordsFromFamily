using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace SueLordFromFamily.dialogue
{
	// Token: 0x0200000F RID: 15
	public abstract class AbsCreateDialogue
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00003ED0 File Offset: 0x000020D0
		// (set) Token: 0x06000080 RID: 128 RVA: 0x00003EC7 File Offset: 0x000020C7
		public CampaignGameStarter CampaignGameStarter { get; set; }

		// Token: 0x06000082 RID: 130 RVA: 0x00003ED8 File Offset: 0x000020D8
		public AbsCreateDialogue(CampaignGameStarter campaignGameStarter)
		{
			this.CampaignGameStarter = campaignGameStarter;
		}

		// Token: 0x06000083 RID: 131
		public abstract void GenerateDialogue();

		// Token: 0x06000084 RID: 132 RVA: 0x00003EEC File Offset: 0x000020EC
		public string LoactionText(string idStr)
		{
			return GameTexts.FindText(idStr, null).ToString();
		}
	}
}
