using System;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace SueLordFromFamily
{
	// Token: 0x02000002 RID: 2
	internal class HeroInfoHelper
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002048 File Offset: 0x00000248
		private void ShowOccupation()
		{
			CharacterObject oneToOneConversationCharacter = CharacterObject.OneToOneConversationCharacter;
			FieldInfo field = oneToOneConversationCharacter.GetType().GetField("_originCharacter", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			CharacterObject characterObject = (CharacterObject)field.GetValue(oneToOneConversationCharacter);
			string name = Enum.GetName(oneToOneConversationCharacter.Occupation.GetType(), oneToOneConversationCharacter.Occupation);
			string name2 = Enum.GetName(oneToOneConversationCharacter.Occupation.GetType(), oneToOneConversationCharacter.Occupation);
			MBTextManager.SetTextVariable("OCCUPATION_NAME", name, false);
			MBTextManager.SetTextVariable("ORGIN_OCCUPATION_NAME", name2, false);
			bool flag = oneToOneConversationCharacter.HeroObject != null;
			if (flag)
			{
				string str = "characterObject.HeroObject,CLAN=";
				TextObject name3 = oneToOneConversationCharacter.HeroObject.Clan.Name;
				InformationManager.DisplayMessage(new InformationMessage(str + ((name3 != null) ? name3.ToString() : null)));
				InformationManager.DisplayMessage(new InformationMessage("characterObject.HeroObject.HeroState=" + oneToOneConversationCharacter.HeroObject.HeroState.ToString()));
			}
			InformationManager.DisplayMessage(new InformationMessage("Occupation=" + name));
		}
	}
}
