using System;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;
using TaleWorlds.GauntletUI.Data;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace SueLordFromFamily.view
{
	// Token: 0x0200000D RID: 13
	internal class KindomScreenVM : ViewModel
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00003BF8 File Offset: 0x00001DF8
		[DataSourceProperty]
		public string BtnName
		{
			get
			{
				return new TextObject("{=sue_clan_create_from_family_clan_service}Clan Service", null).ToString();
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003C1A File Offset: 0x00001E1A
		public KindomScreenVM(GauntletKingdomScreen gauntletClanScreen)
		{
			this._parentScreen = gauntletClanScreen;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003C2C File Offset: 0x00001E2C
		public void ShowClanServiceView()
		{
			bool flag = this._serviceLayer == null;
			bool flag2 = flag;
			if (flag2)
			{
				this._serviceLayer = new GauntletLayer(200, "GauntletLayer");
				this.clanServiceVM = new VassalServiceVM(this, this._parentScreen, new Action(this.OpenBannerEditorWithPlayerClan));
				this._currentMovie = this._serviceLayer.LoadMovie("VassalService", this.clanServiceVM);
				this._serviceLayer.IsFocusLayer = true;
				ScreenManager.TrySetFocus(this._serviceLayer);
				this._serviceLayer.Input.RegisterHotKeyCategory(HotKeyManager.GetCategory("GenericPanelGameKeyCategory"));
				this._parentScreen.AddLayer(this._serviceLayer);
				this._serviceLayer.InputRestrictions.SetInputRestrictions(true, (InputUsageMask)7);
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003CF6 File Offset: 0x00001EF6
		private void OpenBannerEditorWithPlayerClan()
		{
			Game.Current.GameStateManager.PushState(Game.Current.GameStateManager.CreateState<BannerEditorState>(), 0);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00003D1C File Offset: 0x00001F1C
		public override void RefreshValues()
		{
			bool flag = this.clanServiceVM != null;
			if (flag)
			{
				this.clanServiceVM.RefreshValues();
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003D48 File Offset: 0x00001F48
		public void CloseSettingView()
		{
			bool flag = this._serviceLayer != null;
			bool flag2 = flag;
			if (flag2)
			{
				this._serviceLayer.ReleaseMovie(this._currentMovie);
				this._parentScreen.RemoveLayer(this._serviceLayer);
				this._serviceLayer.InputRestrictions.ResetInputRestrictions();
				this._serviceLayer = null;
				this.clanServiceVM = null;
				this.RefreshValues();
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003DB4 File Offset: 0x00001FB4
		public bool IsHotKeyPressed(string hotkey)
		{
			bool flag = this._serviceLayer != null;
			return flag && this._serviceLayer.Input.IsHotKeyReleased(hotkey);
		}

		// Token: 0x0400002B RID: 43
		private GauntletKingdomScreen _parentScreen;

		// Token: 0x0400002C RID: 44
		private IGauntletMovie _currentMovie;

		// Token: 0x0400002D RID: 45
		private GauntletLayer _serviceLayer;

		// Token: 0x0400002E RID: 46
		private VassalServiceVM clanServiceVM;
	}
}
