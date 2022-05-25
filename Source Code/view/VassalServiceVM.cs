using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace SueLordFromFamily.view
{
	// Token: 0x0200000C RID: 12
	internal class VassalServiceVM : ViewModel
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00003858 File Offset: 0x00001A58
		[DataSourceProperty]
		public MBBindingList<VassalClanVM> Clans
		{
			get
			{
				return this._clans;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00003870 File Offset: 0x00001A70
		[DataSourceProperty]
		public MBBindingList<MemberItemVM> Members
		{
			get
			{
				return this._members;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00003888 File Offset: 0x00001A88
		[DataSourceProperty]
		public string DisplayName
		{
			get
			{
				return new TextObject("{=sue_clan_create_from_family_clan_service}Clan Service", null).ToString();
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000038AC File Offset: 0x00001AAC
		public VassalServiceVM(KindomScreenVM parent, GauntletKingdomScreen parentScreen, Action editClanBanner)
		{
			this.parentView = parent;
			this.parentScreen = parentScreen;
			this.editClanBanner = editClanBanner;
			this._clans = new MBBindingList<VassalClanVM>();
			this._members = new MBBindingList<MemberItemVM>();
			Kingdom kingdom = Hero.MainHero.MapFaction as Kingdom;
			bool flag = kingdom.Clans.Count > 1;
			if (flag)
			{
				IEnumerable<Clan> enumerable = Enumerable.Where<Clan>(kingdom.Clans, (Clan obj) => obj != Clan.PlayerClan);
				Enumerable.ToList<Clan>(enumerable).ForEach(delegate(Clan obj)
				{
					this._clans.Add(new VassalClanVM(obj, new Action<VassalClanVM>(this.OnSelectVassal)));
				});
				Clan clan = Enumerable.First<Clan>(enumerable);
				IEnumerable<Hero> heroes = clan.Heroes;
				Enumerable.ToList<Hero>(heroes).ForEach(delegate(Hero obj)
				{
					this._members.Add(new MemberItemVM(obj, new Action<MemberItemVM>(this.OnSelectMember)));
				});
			}
			this.RefreshValues();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003984 File Offset: 0x00001B84
		public override void RefreshValues()
		{
			bool flag = this.Clans != null;
			if (flag)
			{
				Enumerable.ToList<VassalClanVM>(this.Clans).ForEach(delegate(VassalClanVM obj)
				{
					obj.RefreshValues();
				});
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002D81 File Offset: 0x00000F81
		public void OnSelectVassal(VassalClanVM vassalItem)
		{
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002D81 File Offset: 0x00000F81
		public void OnSelectMember(MemberItemVM vassalItem)
		{
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000039D4 File Offset: 0x00001BD4
		public void EditClanBannar()
		{
			InformationManager.DisplayMessage(new InformationMessage("测试修改封臣"));
			Kingdom kingdom = Hero.MainHero.MapFaction as Kingdom;
			bool flag = kingdom.Clans.Count > 1;
			if (flag)
			{
				Clan clan = Enumerable.First<Clan>(Enumerable.Where<Clan>(kingdom.Clans, (Clan obj) => obj != Clan.PlayerClan));
				bool flag2 = clan != null;
				if (flag2)
				{
					this.OpenBannerSelectionScreen(clan, clan.Leader);
				}
				else
				{
					InformationManager.DisplayMessage(new InformationMessage("没有封臣"));
				}
			}
			else
			{
				InformationManager.DisplayMessage(new InformationMessage("没有封臣"));
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003A88 File Offset: 0x00001C88
		private void OpenBannerSelectionScreen(Clan clan, Hero hero)
		{
			NewClanBannerEditorState newClanBannerEditorState = new NewClanBannerEditorState(hero.CharacterObject, clan);
			FieldInfo field = hero.CharacterObject.GetType().GetField("GameStateManager", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			bool flag = null != field;
			if (flag)
			{
				field.SetValue(newClanBannerEditorState, Game.Current.GameStateManager);
			}
			bool flag2 = Game.Current.GameStateManager.GameStateManagerListener != null;
			if (flag2)
			{
				Game.Current.GameStateManager.GameStateManagerListener.OnCreateState(newClanBannerEditorState);
			}
			Game.Current.GameStateManager.PushState(newClanBannerEditorState, 0);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003B1A File Offset: 0x00001D1A
		public void ExecuteCloseWindow()
		{
			this.parentView.CloseSettingView();
			this.OnFinalize();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003B30 File Offset: 0x00001D30
		public void OnFinalize()
		{
			base.OnFinalize();
			bool flag = Game.Current != null;
			bool flag2 = flag;
			if (flag2)
			{
				Game.Current.AfterTick = (Action<float>)Delegate.Remove(Game.Current.AfterTick, new Action<float>(this.AfterTick));
			}
			this.parentView = null;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003B88 File Offset: 0x00001D88
		public void AfterTick(float dt)
		{
			bool flag = this.parentView.IsHotKeyPressed("Exit");
			bool flag2 = flag;
			if (flag2)
			{
				this.ExecuteCloseWindow();
			}
		}

		// Token: 0x04000026 RID: 38
		private KindomScreenVM parentView;

		// Token: 0x04000027 RID: 39
		private GauntletKingdomScreen parentScreen;

		// Token: 0x04000028 RID: 40
		private Action editClanBanner;

		// Token: 0x04000029 RID: 41
		private MBBindingList<VassalClanVM> _clans;

		// Token: 0x0400002A RID: 42
		private MBBindingList<MemberItemVM> _members;
	}
}
