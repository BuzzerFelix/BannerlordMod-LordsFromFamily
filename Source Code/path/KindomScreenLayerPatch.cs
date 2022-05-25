using System;
using HarmonyLib;
using SandBox.GauntletUI;
using SueLordFromFamily.view;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;

namespace SueLordFromFamily.path
{
	// Token: 0x0200000E RID: 14
	[HarmonyPatch(typeof(ScreenBase))]
	internal class KindomScreenLayerPatch
	{
		// Token: 0x0600007D RID: 125 RVA: 0x00003DE8 File Offset: 0x00001FE8
		[HarmonyPatch("AddLayer")]
		public static void Postfix(ref ScreenBase __instance)
		{
			GauntletKingdomScreen gauntletKingdomScreen = __instance as GauntletKingdomScreen;
			bool flag = gauntletKingdomScreen != null && KindomScreenLayerPatch.screenLayer == null;
			bool flag2 = flag;
			if (flag2)
			{
				KindomScreenLayerPatch.screenLayer = new GauntletLayer(100, "GauntletLayer");
				KindomScreenLayerPatch.kindomScreenVM = new KindomScreenVM(gauntletKingdomScreen);
				KindomScreenLayerPatch.screenLayer.LoadMovie("KindomScreen", KindomScreenLayerPatch.kindomScreenVM);
				KindomScreenLayerPatch.screenLayer.InputRestrictions.SetInputRestrictions(true, (InputUsageMask)7);
				gauntletKingdomScreen.AddLayer(KindomScreenLayerPatch.screenLayer);
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003E64 File Offset: 0x00002064
		[HarmonyPatch("RemoveLayer")]
		public static void Prefix(ref ScreenBase __instance, ref ScreenLayer layer)
		{
			bool flag = __instance is GauntletKingdomScreen && KindomScreenLayerPatch.screenLayer != null && layer.Input.IsCategoryRegistered(HotKeyManager.GetCategory("GenericCampaignPanelsGameKeyCategory"));
			bool flag2 = flag;
			if (flag2)
			{
				__instance.RemoveLayer(KindomScreenLayerPatch.screenLayer);
				KindomScreenLayerPatch.kindomScreenVM.OnFinalize();
				KindomScreenLayerPatch.kindomScreenVM = null;
				KindomScreenLayerPatch.screenLayer = null;
			}
		}

		// Token: 0x0400002F RID: 47
		internal static GauntletLayer screenLayer;

		// Token: 0x04000030 RID: 48
		internal static KindomScreenVM kindomScreenVM;
	}
}
