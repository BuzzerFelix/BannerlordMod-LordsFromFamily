using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.Core;

namespace SueLordFromFamily
{
	// Token: 0x02000004 RID: 4
	internal class NewClanBannerEditorState : GameState
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002390 File Offset: 0x00000590
		// (set) Token: 0x06000007 RID: 7 RVA: 0x00002387 File Offset: 0x00000587
		public CharacterObject EditCharacter { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000023A1 File Offset: 0x000005A1
		// (set) Token: 0x06000009 RID: 9 RVA: 0x00002398 File Offset: 0x00000598
		public Clan EditClan { get; set; }

		// Token: 0x0600000B RID: 11 RVA: 0x000023A9 File Offset: 0x000005A9
		public NewClanBannerEditorState(CharacterObject character, Clan clan)
		{
			this.EditCharacter = character;
			this.EditClan = clan;
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000023C4 File Offset: 0x000005C4
		public override bool IsMenuState
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000023D8 File Offset: 0x000005D8
		// (set) Token: 0x0600000E RID: 14 RVA: 0x000023F0 File Offset: 0x000005F0
		public IBannerEditorStateHandler Handler
		{
			get
			{
				return this._handler;
			}
			set
			{
				this._handler = value;
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000023FC File Offset: 0x000005FC
		public Clan GetClan()
		{
			return this.EditClan;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002414 File Offset: 0x00000614
		public CharacterObject GetCharacter()
		{
			return this.EditCharacter;
		}

		// Token: 0x04000001 RID: 1
		private IBannerEditorStateHandler _handler;
	}
}
