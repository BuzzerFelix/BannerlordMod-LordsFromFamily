using System;
using Helpers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace SueLordFromFamily.view
{
	// Token: 0x0200000A RID: 10
	internal class MemberItemVM : ViewModel
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002D84 File Offset: 0x00000F84
		// (set) Token: 0x06000031 RID: 49 RVA: 0x00002D9C File Offset: 0x00000F9C
		[DataSourceProperty]
		public bool IsSelected
		{
			get
			{
				return this._isSelected;
			}
			set
			{
				bool flag = value != this._isSelected;
				if (flag)
				{
					this._isSelected = value;
					base.OnPropertyChanged("IsSelected");
				}
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002DD0 File Offset: 0x00000FD0
		// (set) Token: 0x06000033 RID: 51 RVA: 0x00002DE8 File Offset: 0x00000FE8
		[DataSourceProperty]
		public bool IsChild
		{
			get
			{
				return this._isChild;
			}
			set
			{
				bool flag = value != this._isChild;
				if (flag)
				{
					this._isChild = value;
					base.OnPropertyChanged("IsChild");
				}
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002E1C File Offset: 0x0000101C
		// (set) Token: 0x06000035 RID: 53 RVA: 0x00002E34 File Offset: 0x00001034
		[DataSourceProperty]
		public bool IsMainHero
		{
			get
			{
				return this._isMainHero;
			}
			set
			{
				bool flag = value != this._isMainHero;
				if (flag)
				{
					this._isMainHero = value;
					base.OnPropertyChanged("IsMainHero");
				}
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002E68 File Offset: 0x00001068
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00002E80 File Offset: 0x00001080
		[DataSourceProperty]
		public bool IsFamilyMember
		{
			get
			{
				return this._isFamilyMember;
			}
			set
			{
				bool flag = value != this._isFamilyMember;
				if (flag)
				{
					this._isFamilyMember = value;
					base.OnPropertyChanged("IsFamilyMember");
				}
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002EB4 File Offset: 0x000010B4
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00002ECC File Offset: 0x000010CC
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

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002F00 File Offset: 0x00001100
		// (set) Token: 0x0600003B RID: 59 RVA: 0x00002F18 File Offset: 0x00001118
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

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002F4C File Offset: 0x0000114C
		// (set) Token: 0x0600003D RID: 61 RVA: 0x00002F64 File Offset: 0x00001164
		[DataSourceProperty]
		public string LocationText
		{
			get
			{
				return this._locationText;
			}
			set
			{
				bool flag = value != this._locationText;
				if (flag)
				{
					this._locationText = value;
					base.OnPropertyChanged("LocationText");
				}
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00002F98 File Offset: 0x00001198
		// (set) Token: 0x0600003F RID: 63 RVA: 0x00002FB0 File Offset: 0x000011B0
		[DataSourceProperty]
		public string RelationToMainHeroText
		{
			get
			{
				return this._relationToMainHeroText;
			}
			set
			{
				bool flag = value != this._relationToMainHeroText;
				if (flag)
				{
					this._relationToMainHeroText = value;
					base.OnPropertyChanged("RelationToMainHeroText");
				}
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002FE4 File Offset: 0x000011E4
		// (set) Token: 0x06000041 RID: 65 RVA: 0x00002FFC File Offset: 0x000011FC
		[DataSourceProperty]
		public string GovernorOfText
		{
			get
			{
				return this._governorOfText;
			}
			set
			{
				bool flag = value != this._governorOfText;
				if (flag)
				{
					this._governorOfText = value;
					base.OnPropertyChanged("GovernorOfText");
				}
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00003030 File Offset: 0x00001230
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00003048 File Offset: 0x00001248
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

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000044 RID: 68 RVA: 0x0000307C File Offset: 0x0000127C
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00003094 File Offset: 0x00001294
		[DataSourceProperty]
		public string CurrentActionText
		{
			get
			{
				return this._currentActionText;
			}
			set
			{
				bool flag = value != this._currentActionText;
				if (flag)
				{
					this._currentActionText = value;
					base.OnPropertyChanged("CurrentActionText");
				}
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000030C8 File Offset: 0x000012C8
		public MemberItemVM(Hero hero, Action<MemberItemVM> onCharacterSelect)
		{
			this._hero = hero;
			this._onCharacterSelect = onCharacterSelect;
			CharacterCode characterCode = CharacterCode.CreateFrom(hero.CharacterObject);
			this.Visual = new ImageIdentifierVM(characterCode);
			this.Banner_9 = new ImageIdentifierVM(BannerCode.CreateFrom(hero.ClanBanner), true);
			this.RefreshValues();
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003124 File Offset: 0x00001324
		public override void RefreshValues()
		{
			base.RefreshValues();
			this.Name = this._hero.Name.ToString();
			this.CurrentActionText = ((this._hero != Hero.MainHero) ? CampaignUIHelper.GetHeroBehaviorText(this._hero) : "");
			bool flag = this._hero.PartyBelongedToAsPrisoner != null;
			if (flag)
			{
				TextObject textObject = new TextObject("{=a8nRxITn}Prisoner of {PARTY_NAME}", null);
				textObject.SetTextVariable("PARTY_NAME", this._hero.PartyBelongedToAsPrisoner.Name);
				this.LocationText = textObject.ToString();
			}
			else
			{
				this.LocationText = ((this._hero != Hero.MainHero) ? StringHelpers.GetLastKnownLocation(this._hero).ToString() : " ");
			}
		}

		// Token: 0x0400000C RID: 12
		private readonly Action<MemberItemVM> _onCharacterSelect;

		// Token: 0x0400000D RID: 13
		private readonly Hero _hero;

		// Token: 0x0400000E RID: 14
		private ImageIdentifierVM _visual;

		// Token: 0x0400000F RID: 15
		private ImageIdentifierVM _banner_9;

		// Token: 0x04000010 RID: 16
		private bool _isSelected;

		// Token: 0x04000011 RID: 17
		private bool _isChild;

		// Token: 0x04000012 RID: 18
		private bool _isMainHero;

		// Token: 0x04000013 RID: 19
		private bool _isFamilyMember;

		// Token: 0x04000014 RID: 20
		private string _name;

		// Token: 0x04000015 RID: 21
		private string _locationText;

		// Token: 0x04000016 RID: 22
		private string _relationToMainHeroText;

		// Token: 0x04000017 RID: 23
		private string _governorOfText;

		// Token: 0x04000018 RID: 24
		private string _currentActionText;
	}
}
