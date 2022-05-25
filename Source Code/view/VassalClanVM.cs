using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.CampaignSystem.ViewModelCollection.KingdomManagement.KingdomClan;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace SueLordFromFamily.view
{
	// Token: 0x0200000B RID: 11
	internal class VassalClanVM : ViewModel
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000031F0 File Offset: 0x000013F0
		[DataSourceProperty]
		public string EditVassalBannerText
		{
			get
			{
				return new TextObject("{=sue_clan_create_from_family_edit_banner}Edit Banner", null).ToString();
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00003214 File Offset: 0x00001414
		[DataSourceProperty]
		public string EditVassalNameText
		{
			get
			{
				return new TextObject("{=sue_clan_create_from_family_edit_name}Edit Name", null).ToString();
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00003238 File Offset: 0x00001438
		// (set) Token: 0x0600004B RID: 75 RVA: 0x00003250 File Offset: 0x00001450
		[DataSourceProperty]
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				bool flag = value != this._name;
				if (flag)
				{
					this._name = value;
					base.OnPropertyChanged("Name");
				}
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00003284 File Offset: 0x00001484
		// (set) Token: 0x0600004D RID: 77 RVA: 0x0000329C File Offset: 0x0000149C
		[DataSourceProperty]
		public int ClanType
		{
			get
			{
				return this._clanType;
			}
			set
			{
				bool flag = value != this._clanType;
				if (flag)
				{
					this._clanType = value;
					base.OnPropertyChanged("ClanType");
				}
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600004E RID: 78 RVA: 0x000032D0 File Offset: 0x000014D0
		// (set) Token: 0x0600004F RID: 79 RVA: 0x000032E8 File Offset: 0x000014E8
		[DataSourceProperty]
		public int NumOfMembers
		{
			get
			{
				return this._numOfMembers;
			}
			set
			{
				bool flag = value != this._numOfMembers;
				if (flag)
				{
					this._numOfMembers = value;
					base.OnPropertyChanged("NumOfMembers");
				}
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000050 RID: 80 RVA: 0x0000331C File Offset: 0x0000151C
		// (set) Token: 0x06000051 RID: 81 RVA: 0x00003334 File Offset: 0x00001534
		[DataSourceProperty]
		public int NumOfFiefs
		{
			get
			{
				return this._numOfFiefs;
			}
			set
			{
				bool flag = value != this._numOfFiefs;
				if (flag)
				{
					this._numOfFiefs = value;
					base.OnPropertyChanged("NumOfFiefs");
				}
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00003368 File Offset: 0x00001568
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00003380 File Offset: 0x00001580
		[DataSourceProperty]
		public string TierText
		{
			get
			{
				return this._tierText;
			}
			set
			{
				bool flag = value != this._tierText;
				if (flag)
				{
					this._tierText = value;
					base.OnPropertyChanged("TierText");
				}
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000054 RID: 84 RVA: 0x000033B4 File Offset: 0x000015B4
		// (set) Token: 0x06000055 RID: 85 RVA: 0x000033CC File Offset: 0x000015CC
		[DataSourceProperty]
		public ImageIdentifierVM Banner
		{
			get
			{
				return this._banner;
			}
			set
			{
				bool flag = value != this._banner;
				if (flag)
				{
					this._banner = value;
					base.OnPropertyChanged("Banner");
				}
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00003400 File Offset: 0x00001600
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00003418 File Offset: 0x00001618
		[DataSourceProperty]
		public ImageIdentifierVM Banner_9
		{
			get
			{
				return this._banner_9;
			}
			set
			{
				bool flag = value != this._banner_9;
				if (flag)
				{
					this._banner_9 = value;
					base.OnPropertyChanged("Banner_9");
				}
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000058 RID: 88 RVA: 0x0000344C File Offset: 0x0000164C
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00003464 File Offset: 0x00001664
		[DataSourceProperty]
		public MBBindingList<HeroVM> Members
		{
			get
			{
				return this._members;
			}
			set
			{
				bool flag = value != this._members;
				if (flag)
				{
					this._members = value;
					base.OnPropertyChanged("Members");
				}
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00003498 File Offset: 0x00001698
		// (set) Token: 0x0600005B RID: 91 RVA: 0x000034B0 File Offset: 0x000016B0
		[DataSourceProperty]
		public MBBindingList<KingdomClanFiefItemVM> Fiefs
		{
			get
			{
				return this._fiefs;
			}
			set
			{
				bool flag = value != this._fiefs;
				if (flag)
				{
					this._fiefs = value;
					base.OnPropertyChanged("Fiefs");
				}
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600005C RID: 92 RVA: 0x000034E4 File Offset: 0x000016E4
		// (set) Token: 0x0600005D RID: 93 RVA: 0x000034FC File Offset: 0x000016FC
		[DataSourceProperty]
		public int Influence
		{
			get
			{
				return this._influence;
			}
			set
			{
				bool flag = value != this._influence;
				if (flag)
				{
					this._influence = value;
					base.OnPropertyChanged("Influence");
				}
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00003530 File Offset: 0x00001730
		// (set) Token: 0x0600005F RID: 95 RVA: 0x00003548 File Offset: 0x00001748
		[DataSourceProperty]
		public ImageIdentifierVM Visual
		{
			get
			{
				return this._visual;
			}
			set
			{
				bool flag = value != this._visual;
				if (flag)
				{
					this._visual = value;
					base.OnPropertyChanged("Visual");
				}
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000357B File Offset: 0x0000177B
		public VassalClanVM(Clan clan, Action<VassalClanVM> onSelect)
		{
			this.Clan = clan;
			this._onSelect = onSelect;
			this.RefreshValues();
			this.Refresh();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000035A8 File Offset: 0x000017A8
		public void EditClanBanner()
		{
			this.OpenBannerSelectionScreen(this.Clan, this.Clan.Leader);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000035C4 File Offset: 0x000017C4
		public void EditClanName() {
			InformationManager.ShowTextInquiry(new TextInquiryData(
                new TextObject("{=JJiKk4ow}Select your family name: ", null).ToString(),
                string.Empty,
                true,
                false,
                GameTexts.FindText("str_done", null).ToString(),
                null,
                new Action<string>(this.OnChangeClanNameDone),
                null,
                false,
                new Func<string, bool>(this.IsNewClanNameApplicable),
                "",
                ""), false);

		} 

        // Token: 0x06000063 RID: 99 RVA: 0x0000362C File Offset: 0x0000182C
        private bool IsNewClanNameApplicable(string input)
		{
			return input.Length <= 50 && input.Length >= 1;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003658 File Offset: 0x00001858
		private void OnChangeClanNameDone(string newClanName)
		{
			TextObject textObject = new TextObject(newClanName ?? "", null);
			this.Clan.ChangeClanName(textObject);
			this.Name = textObject.ToString();
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003694 File Offset: 0x00001894
		private void OpenBannerSelectionScreen(Clan clan, Hero hero)
		{
			NewClanBannerEditorState newClanBannerEditorState = new NewClanBannerEditorState(hero.CharacterObject, clan);
			bool flag = Game.Current.GameStateManager.GameStateManagerListener != null;
			if (flag)
			{
				Game.Current.GameStateManager.GameStateManagerListener.OnCreateState(newClanBannerEditorState);
			}
			Game.Current.GameStateManager.PushState(newClanBannerEditorState, 0);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000036F0 File Offset: 0x000018F0
		public override void RefreshValues()
		{
			base.RefreshValues();
			CharacterCode characterCode = CampaignUIHelper.GetCharacterCode(this.Clan.Leader.CharacterObject, false);
			this.Visual = new ImageIdentifierVM(characterCode);
			this.Banner = new ImageIdentifierVM(this.Clan.Banner);
			this.Banner_9 = new ImageIdentifierVM(BannerCode.CreateFrom(this.Clan.Banner), true);
			this.Name = this.Clan.Name.ToString();
			GameTexts.SetVariable("TIER", this.Clan.Tier);
			this.TierText = GameTexts.FindText("str_clan_tier", null).ToString();
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000037A4 File Offset: 0x000019A4
		public void Refresh()
		{
			this.Members = new MBBindingList<HeroVM>();
			this.ClanType = 0;
			bool isUnderMercenaryService = this.Clan.IsUnderMercenaryService;
			if (isUnderMercenaryService)
			{
				this.ClanType = 2;
			}
			else
			{
				bool flag = this.Clan.Kingdom.RulingClan == this.Clan;
				if (flag)
				{
					this.ClanType = 1;
				}
			}
			this.NumOfMembers = this.Members.Count;
			this.Fiefs = new MBBindingList<KingdomClanFiefItemVM>();
			IEnumerable<Settlement> settlements = this.Clan.Settlements;
			this.NumOfFiefs = this.Fiefs.Count;
			this.Influence = (int)this.Clan.Influence;
		}

		// Token: 0x04000019 RID: 25
		private readonly Action<VassalClanVM> _onSelect;

		// Token: 0x0400001A RID: 26
		public readonly Clan Clan;

		// Token: 0x0400001B RID: 27
		private string _name;

		// Token: 0x0400001C RID: 28
		private ImageIdentifierVM _visual;

		// Token: 0x0400001D RID: 29
		private ImageIdentifierVM _banner;

		// Token: 0x0400001E RID: 30
		private ImageIdentifierVM _banner_9;

		// Token: 0x0400001F RID: 31
		private MBBindingList<HeroVM> _members;

		// Token: 0x04000020 RID: 32
		private MBBindingList<KingdomClanFiefItemVM> _fiefs;

		// Token: 0x04000021 RID: 33
		private int _influence;

		// Token: 0x04000022 RID: 34
		private int _numOfMembers;

		// Token: 0x04000023 RID: 35
		private int _numOfFiefs;

		// Token: 0x04000024 RID: 36
		private string _tierText;

		// Token: 0x04000025 RID: 37
		private int _clanType = -1;
	}
}
