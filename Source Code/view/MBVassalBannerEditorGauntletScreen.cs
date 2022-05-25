using System;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Engine;
using TaleWorlds.Engine.Screens;
using TaleWorlds.InputSystem;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.View.Screen;

namespace SueLordFromFamily.view
{
	// Token: 0x02000009 RID: 9
	[GameStateScreen(typeof(NewClanBannerEditorState))]
	internal class MBVassalBannerEditorGauntletScreen : ScreenBase, IGameStateListener
	{
		// Token: 0x06000024 RID: 36 RVA: 0x00002B80 File Offset: 0x00000D80
		public MBVassalBannerEditorGauntletScreen(NewClanBannerEditorState bannerEditorState)
		{
			LoadingWindow.EnableGlobalLoadingWindow();
			this._clan = bannerEditorState.GetClan();
			this._bannerEditorLayer = new BannerEditorView(bannerEditorState.GetCharacter(), bannerEditorState.GetClan().Banner, new ControlCharacterCreationStage(this.OnDone), new TextObject("{=WiNRdfsm}Done", null), new ControlCharacterCreationStage(this.OnCancel), new TextObject("{=3CpNUnVl}Cancel", null), null, null, null, null, null);
			this._bannerEditorLayer.DataSource.SetClanRelatedRules(bannerEditorState.GetClan().Kingdom == null);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002C18 File Offset: 0x00000E18
		protected override void OnFrameTick(float dt)
		{
			base.OnFrameTick(dt);
			this._bannerEditorLayer.OnTick(dt);
			bool flag = Input.IsKeyReleased((InputKey)1);
			if (flag)
			{
				this.OnCancel();
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002C50 File Offset: 0x00000E50
		public void OnDone()
		{
			uint primaryColor = this._bannerEditorLayer.DataSource.BannerVM.GetPrimaryColor();
			uint sigilColor = this._bannerEditorLayer.DataSource.BannerVM.GetSigilColor();
			this._clan.Color = primaryColor;
			this._clan.Color2 = sigilColor;
			Game.Current.GameStateManager.PopState(0);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002CB5 File Offset: 0x00000EB5
		public void OnCancel()
		{
			Game.Current.GameStateManager.PopState(0);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002CC9 File Offset: 0x00000EC9
		protected override void OnInitialize()
		{
			base.OnInitialize();
			this._oldGameStateManagerDisabledStatus = Game.Current.GameStateManager.ActiveStateDisabledByUser;
			Game.Current.GameStateManager.ActiveStateDisabledByUser = true;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002CFC File Offset: 0x00000EFC
		protected override void OnFinalize()
		{
			base.OnFinalize();
			this._bannerEditorLayer.OnFinalize();
			bool globalLoadingWindowState = LoadingWindow.GetGlobalLoadingWindowState();
			if (globalLoadingWindowState)
			{
				LoadingWindow.DisableGlobalLoadingWindow();
			}
			Game.Current.GameStateManager.ActiveStateDisabledByUser = this._oldGameStateManagerDisabledStatus;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002D44 File Offset: 0x00000F44
		protected override void OnActivate()
		{
			base.OnActivate();
			base.AddLayer(this._bannerEditorLayer.GauntletLayer);
			base.AddLayer(this._bannerEditorLayer.SceneLayer);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002D72 File Offset: 0x00000F72
		protected override void OnDeactivate()
		{
			this._bannerEditorLayer.OnDeactivate();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002D81 File Offset: 0x00000F81
		void IGameStateListener.OnActivate()
		{
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002D81 File Offset: 0x00000F81
		void IGameStateListener.OnDeactivate()
		{
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002D81 File Offset: 0x00000F81
		void IGameStateListener.OnInitialize()
		{
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002D81 File Offset: 0x00000F81
		void IGameStateListener.OnFinalize()
		{
		}

		// Token: 0x04000008 RID: 8
		private const int ViewOrderPriority = 16;

		// Token: 0x04000009 RID: 9
		private readonly BannerEditorView _bannerEditorLayer;

		// Token: 0x0400000A RID: 10
		private readonly Clan _clan;

		// Token: 0x0400000B RID: 11
		private bool _oldGameStateManagerDisabledStatus;
	}
}
