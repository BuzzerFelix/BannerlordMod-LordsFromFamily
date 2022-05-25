using System;
using TaleWorlds.CampaignSystem;

namespace SueLordFromFamily.dialogue
{
	// Token: 0x02000012 RID: 18
	internal class DialogueCreator
	{
		// Token: 0x060000A8 RID: 168 RVA: 0x000050A8 File Offset: 0x000032A8
		public DialogueCreator Id(string id)
		{
			this.id = id;
			return this;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000050C4 File Offset: 0x000032C4
		public DialogueCreator IsPlayer(bool isPlayer)
		{
			this.isPlayer = isPlayer;
			return this;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000050E0 File Offset: 0x000032E0
		public DialogueCreator InputOrder(string inputOrder)
		{
			this.inputOrder = inputOrder;
			return this;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000050FC File Offset: 0x000032FC
		public DialogueCreator OutOrder(string outOrder)
		{
			this.outOrder = outOrder;
			return this;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00005118 File Offset: 0x00003318
		public DialogueCreator Text(string text)
		{
			this.text = text;
			return this;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00005134 File Offset: 0x00003334
		public DialogueCreator Condition(DialogueCreator.ConditionDelegate condition)
		{
			this.condition = condition;
			return this;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00005150 File Offset: 0x00003350
		public DialogueCreator Result(DialogueCreator.ResultDelegate result)
		{
			this.result = result;
			return this;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000516C File Offset: 0x0000336C
		public void CreateAndAdd(CampaignGameStarter campaignGameStarter)
		{
			bool flag = this.isPlayer;
			if (flag)
			{
				campaignGameStarter.AddRepeatablePlayerLine(this.id, this.inputOrder, this.outOrder, this.text, this.NewCondition(this.condition), this.NewResult(this.result), 100, null);
			}
			else
			{
				campaignGameStarter.AddDialogLine(this.id, this.inputOrder, this.outOrder, this.text, this.NewCondition(this.condition), this.NewResult(this.result), 100, null);
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00005200 File Offset: 0x00003400
		public ConversationSentence.OnConsequenceDelegate NewResult(DialogueCreator.ResultDelegate action)
		{
			bool flag = action != null;
			ConversationSentence.OnConsequenceDelegate onConsequenceDelegate;
			if (flag)
			{
				onConsequenceDelegate = new ConversationSentence.OnConsequenceDelegate(action.Invoke);
			}
			else
			{
				onConsequenceDelegate = null;
			}
			return onConsequenceDelegate;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000522C File Offset: 0x0000342C
		public ConversationSentence.OnConditionDelegate NewCondition(DialogueCreator.ConditionDelegate action)
		{
			bool flag = action != null;
			ConversationSentence.OnConditionDelegate onConditionDelegate;
			if (flag)
			{
				onConditionDelegate = new ConversationSentence.OnConditionDelegate(action.Invoke);
			}
			else
			{
				onConditionDelegate = null;
			}
			return onConditionDelegate;
		}

		// Token: 0x04000038 RID: 56
		private string id;

		// Token: 0x04000039 RID: 57
		private string inputOrder;

		// Token: 0x0400003A RID: 58
		private string outOrder;

		// Token: 0x0400003B RID: 59
		private string text;

		// Token: 0x0400003C RID: 60
		private DialogueCreator.ConditionDelegate condition;

		// Token: 0x0400003D RID: 61
		private DialogueCreator.ResultDelegate result;

		// Token: 0x0400003E RID: 62
		private bool isPlayer;

		// Token: 0x02000026 RID: 38
		// (Invoke) Token: 0x060000E9 RID: 233
		public delegate bool ConditionDelegate();

		// Token: 0x02000027 RID: 39
		// (Invoke) Token: 0x060000ED RID: 237
		public delegate void ResultDelegate();
	}
}
