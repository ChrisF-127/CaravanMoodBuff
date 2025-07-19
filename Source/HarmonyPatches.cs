using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace CaravanMoodBuff
{
	[HarmonyPatch(typeof(CaravansBattlefield), "CheckWonBattle")]
	static class Patch_CaravansBattlefield_CheckWonBattle
	{
		[HarmonyTranspiler]
		public static IEnumerable<CodeInstruction> Test(IEnumerable<CodeInstruction> instructions)
		{
			var appliedPatch = false;
			//Log.Message("CheckWonBattle");
			CodeInstruction prevInstruction = null;
			foreach (var instruction in instructions)
			{
				if (!appliedPatch)
				{
					if (instruction.opcode == OpCodes.Ldc_I4_1)
					{
						prevInstruction = instruction;
						continue;
					}
					else if (instruction.opcode == OpCodes.Stfld && instruction.operand?.ToString().Contains("wonBattle") == true)
					{
						var newInstruction = new CodeInstruction(OpCodes.Call, typeof(MapParent).GetProperty("Map", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetGetMethod(true));
						//Log.Warning(newInstruction.ToString());
						yield return newInstruction;

						newInstruction = new CodeInstruction(OpCodes.Call, typeof(Patch_CaravansBattlefield_CheckWonBattle).GetMethod(nameof(ApplyMoodBuff), BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic));
						//Log.Warning(newInstruction.ToString());
						yield return newInstruction;

						newInstruction = new CodeInstruction(OpCodes.Ldarg_0);
						//Log.Warning(newInstruction.ToString());
						yield return newInstruction;

						appliedPatch = true;
					}

					if (prevInstruction != null)
					{
						//Log.Message(prevInstruction.ToString());
						yield return prevInstruction;
						prevInstruction = null;
					}
				}

				//Log.Message(instruction.ToString());
				yield return instruction;
			}

			if (!appliedPatch)
				Log.Error($"{nameof(CaravanMoodBuff)}: {nameof(Patch_CaravansBattlefield_CheckWonBattle)} transpiler patch could not be applied; please report this error");
		}

		public static void ApplyMoodBuff(Map map)
		{
			foreach (var pawn in map.mapPawns.AllPawns)
			{
				if (pawn?.IsColonist == true)
				{
					pawn.needs?.mood?.thoughts?.memories?.TryGainMemory(ThoughtDefOfCaravanMoodBuff.CaravanBattleWon);
				}
			}
		}
	}

	[HarmonyPatch(typeof(FormCaravanComp), "CompTickInterval")]
	static class Patch_FormCaravanComp_CompTickInterval
	{
		[HarmonyTranspiler]
		public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			var appliedPatch = false;
			//Log.Message("--- START ---");
			foreach (var instruction in instructions)
			{
				if (!appliedPatch && instruction.opcode == OpCodes.Ldarg_0 && instruction.labels.Count == 5)
				{
					var last = instruction.labels.Last();
					instruction.labels.Remove(last);

					var newInstruction = new CodeInstruction(OpCodes.Ldarg_0);
					newInstruction.labels.Add(last);
					//Log.Warning(newInstruction.ToString());
					yield return newInstruction;

					newInstruction = new CodeInstruction(OpCodes.Call, typeof(FormCaravanComp).GetProperty("MapParent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetGetMethod(true));
					//Log.Warning(newInstruction.ToString());
					yield return newInstruction;

					newInstruction = new CodeInstruction(OpCodes.Call, typeof(Patch_FormCaravanComp_CompTickInterval).GetMethod(nameof(ApplyMoodBuff), BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic));
					//Log.Warning(newInstruction.ToString());
					yield return newInstruction;

					appliedPatch = true;
				}
				//Log.Message(instruction.ToString());
				yield return instruction;
			}

			if (!appliedPatch)
				Log.Error($"{nameof(CaravanMoodBuff)}: {nameof(Patch_FormCaravanComp_CompTickInterval)} transpiler patch could not be applied; please report this error");
		}

		public static void ApplyMoodBuff(MapParent mapParent)
		{
			if (mapParent.GetType() != typeof(CaravansBattlefield))
			{
				Log.Message("Patch_FormCaravanComp_CompTick");
				foreach (var pawn in mapParent.Map.mapPawns.AllPawns.ToArray())
				{
					if (pawn?.IsColonist == true)
					{
						pawn.needs?.mood?.thoughts?.memories?.TryGainMemory(ThoughtDefOfCaravanMoodBuff.CaravanEventSuccess);
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
