using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace CaravanMoodBuff
{
	public class CaravanMoodBuff : Mod
	{
		#region PROPERTIES
		public static CaravanMoodBuff Instance { get; private set; }
		public static CaravanMoodBuffSettings Settings { get; private set; }
		#endregion

		#region CONSTRUCTORS
		static CaravanMoodBuff()
		{
			var harmony = new Harmony("syrus.caravanmoodbuff");
			harmony.PatchAll();
		}

		public CaravanMoodBuff(ModContentPack content) : base(content)
		{
			Instance = this;

			LongEventHandler.ExecuteWhenFinished(Initialize);
		}
		#endregion

		#region OVERRIDES
		public override string SettingsCategory() =>
			"Caravan Mood Buff";

		public override void DoSettingsWindowContents(Rect inRect)
		{
			base.DoSettingsWindowContents(inRect);

			Settings.DoSettingsWindowContents(inRect);
		}
		#endregion

		#region PRIVATE METHODS
		private void Initialize()
		{
			CaravanMoodBuffSettings.InitializeStatics();

			Settings = GetSettings<CaravanMoodBuffSettings>();
		}
		#endregion
	}
}
