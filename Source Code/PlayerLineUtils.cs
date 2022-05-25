using System;
using System.Collections.Generic;
using System.Reflection;
using TaleWorlds.CampaignSystem;

namespace SueLordFromFamily
{
	// Token: 0x02000005 RID: 5
	internal class PlayerLineUtils
	{
		// Token: 0x06000011 RID: 17 RVA: 0x0000242C File Offset: 0x0000062C
		public static void cleanRepeatableLine(CampaignGameStarter campaignGameStarter, string flag)
		{
			FieldInfo field = campaignGameStarter.GetType().GetField("_conversationManager", BindingFlags.Instance | BindingFlags.NonPublic);
			object value = field.GetValue(campaignGameStarter);
			bool flag2 = value != null;
			if (flag2)
			{
				ConversationManager conversationManager = (ConversationManager)field.GetValue(campaignGameStarter);
				FieldInfo field2 = conversationManager.GetType().GetField("_sentences", BindingFlags.Instance | BindingFlags.NonPublic);
				bool flag3 = null != field2;
				if (flag3)
				{
					List<ConversationSentence> list = (List<ConversationSentence>)field2.GetValue(conversationManager);
					list.RemoveAll((ConversationSentence s) => flag == s.Id);
				}
			}
		}
	}
}
