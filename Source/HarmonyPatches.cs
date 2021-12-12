using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace CaravanMoodBuff
{
	[StaticConstructorOnStartup]
	public static class HarmonyPatches
	{
		static HarmonyPatches()
		{
			Harmony harmony = new Harmony("syrus.caravanmoodbuff");

			harmony.PatchAll();
		}
	}

	[HarmonyPatch(typeof(CaravansBattlefield), "CheckWonBattle")]
	static class Patch_CaravansBattlefield_CheckWonBattle
	{
		[HarmonyPrefix]
		public static void Prefix(CaravansBattlefield __instance, out bool __state)
		{
			__state = __instance.wonBattle;
		}

		[HarmonyPostfix]
		public static void Postfix(CaravansBattlefield __instance, bool __state)
		{
			// __instance.WonBattle changed from false to true
			if (!__state && __instance?.WonBattle == true && __instance.Map?.IsPlayerHome == false)
			{
				//Log.Message("Patch_CaravansBattlefield_CheckWonBattle");
				foreach (var pawn in __instance.Map.mapPawns.AllPawns)
				{
					if (pawn?.IsColonist == true)
					{
						pawn.needs?.mood?.thoughts?.memories?.TryGainMemory(ThoughtDefOfCaravanMoodBuff.CaravanBattleWon);
					}
				}
			}
		}
	}

	[HarmonyPatch(typeof(FormCaravanComp), "CompTick")]
	static class Patch_FormCaravanComp_CompTick
	{
		[HarmonyPrefix]
		public static void Prefix(FormCaravanComp __instance, out bool __state)
		{
			__state = __instance.anyActiveThreatLastTick && __instance.Reform && __instance.CanFormOrReformCaravanNow;
		}

		[HarmonyPostfix]
		public static void Postfix(FormCaravanComp __instance, bool __state)
		{
			// (anyActiveThreatLastTick && Reform && CanFormOrReformCaravanNow) [=> __state] && !anyActiveThreatNow [=> !__instance.anyActiveThreatLastTick]
			if (__state && __instance?.anyActiveThreatLastTick == false)
			{
				var mapParent = __instance.MapParent;
				if (mapParent?.Map?.IsPlayerHome == false
					&& mapParent.GetType() != typeof(CaravansBattlefield))
				{
					//Log.Message("Patch_FormCaravanComp_CompTick");
					foreach (var pawn in mapParent.Map.mapPawns.AllPawns)
					{
						if (pawn?.IsColonist == true)
						{
							pawn.needs?.mood?.thoughts?.memories?.TryGainMemory(ThoughtDefOfCaravanMoodBuff.CaravanEventSuccess);
						}
					}
				}
			}
		}
	}

	//[HarmonyPatch(typeof(GenSpawn), "Spawn", new Type[] { typeof(Thing), typeof(IntVec3), typeof(Map), typeof(Rot4), typeof(WipeMode), typeof(bool) })]
	//static class Patch_GenSpawn_Spawn
	//{
	//	[HarmonyPostfix]
	//	public static void Postfix(Thing newThing, Map map, bool respawningAfterLoad)
	//	{
	//		if (!respawningAfterLoad && !map.IsPlayerHome && newThing is Pawn pawn && pawn.IsColonist)
	//		{
	//			Log.Message("Patch_GenSpawn_Spawn: " + respawningAfterLoad + " " + map.IsPlayerHome + " " + newThing);
	//			Log.Message("Adding buff to: " + pawn);
	//			pawn.needs?.mood?.thoughts?.memories?.TryGainMemory(ThoughtDefOfCaravanMoodBuff.CaravanEvent);
	//		}
	//	}
	//}

	//[HarmonyPatch(typeof(Pawn), "ExitMap")]
	//static class Patch_Pawn_ExitMap
	//{
	//	[HarmonyPostfix]
	//	public static void Postfix(Pawn __instance)
	//	{
	//		Log.Message("Patch_Pawn_ExitMap");
	//		Log.Message("Removing buff from: " + __instance);
	//		__instance?.needs?.mood?.thoughts?.memories?.RemoveMemoriesOfDef(ThoughtDefOfCaravanMoodBuff.CaravanEvent);
	//	}
	//}
}
