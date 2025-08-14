using SyControlsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace CaravanMoodBuff
{
	public class CaravanMoodBuffSettings : ModSettings
	{
		#region PROPERTIES
		public static float Default_CaravanEventActive_MoodEffect { get; private set; }
		public float CaravanEventActive_MoodEffect
		{
			get => ThoughtDefOfCaravanMoodBuff.CaravanEventActive.stages[0].baseMoodEffect;
			set => ThoughtDefOfCaravanMoodBuff.CaravanEventActive.stages[0].baseMoodEffect = value;
		}

		public static float Default_CaravanTraveling_MoodEffect { get; private set; }
		public float CaravanTraveling_MoodEffect
		{
			get => ThoughtDefOfCaravanMoodBuff.CaravanTraveling.stages[0].baseMoodEffect;
			set => ThoughtDefOfCaravanMoodBuff.CaravanTraveling.stages[0].baseMoodEffect = value;
		}

		public static float Default_CaravanForming_MoodEffect { get; private set; }
		public float CaravanForming_MoodEffect
		{
			get => ThoughtDefOfCaravanMoodBuff.CaravanForming.stages[0].baseMoodEffect;
			set => ThoughtDefOfCaravanMoodBuff.CaravanForming.stages[0].baseMoodEffect = value;
		}

		public static float Default_CaravanEventSuccess_MoodEffect { get; private set; }
		public float CaravanEventSuccess_MoodEffect
		{
			get => ThoughtDefOfCaravanMoodBuff.CaravanEventSuccess.stages[0].baseMoodEffect;
			set => ThoughtDefOfCaravanMoodBuff.CaravanEventSuccess.stages[0].baseMoodEffect = value;
		}
		public static float Default_CaravanEventSuccess_DurationDays { get; private set; }
		public float CaravanEventSuccess_DurationDays
		{
			get => ThoughtDefOfCaravanMoodBuff.CaravanEventSuccess.durationDays;
			set => ThoughtDefOfCaravanMoodBuff.CaravanEventSuccess.durationDays = value;
		}

		public static float Default_CaravanBattleWon_MoodEffect { get; private set; }
		public float CaravanBattleWon_MoodEffect
		{
			get => ThoughtDefOfCaravanMoodBuff.CaravanBattleWon.stages[0].baseMoodEffect;
			set => ThoughtDefOfCaravanMoodBuff.CaravanBattleWon.stages[0].baseMoodEffect = value;
		}
		public static float Default_CaravanBattleWon_DurationDays { get; private set; }
		public float CaravanBattleWon_DurationDays
		{
			get => ThoughtDefOfCaravanMoodBuff.CaravanBattleWon.durationDays;
			set => ThoughtDefOfCaravanMoodBuff.CaravanBattleWon.durationDays = value;
		}
		#endregion

		#region PUBLIC METHODS
		public static void InitializeStatics()
		{
			Default_CaravanEventActive_MoodEffect = ThoughtDefOfCaravanMoodBuff.CaravanEventActive.stages[0].baseMoodEffect;

			Default_CaravanTraveling_MoodEffect = ThoughtDefOfCaravanMoodBuff.CaravanTraveling.stages[0].baseMoodEffect;

			Default_CaravanForming_MoodEffect = ThoughtDefOfCaravanMoodBuff.CaravanForming.stages[0].baseMoodEffect;

			Default_CaravanEventSuccess_MoodEffect = ThoughtDefOfCaravanMoodBuff.CaravanEventSuccess.stages[0].baseMoodEffect;
			Default_CaravanEventSuccess_DurationDays = ThoughtDefOfCaravanMoodBuff.CaravanEventSuccess.durationDays;

			Default_CaravanBattleWon_MoodEffect = ThoughtDefOfCaravanMoodBuff.CaravanBattleWon.stages[0].baseMoodEffect;
			Default_CaravanBattleWon_DurationDays = ThoughtDefOfCaravanMoodBuff.CaravanBattleWon.durationDays;
		}

		public void DoSettingsWindowContents(Rect inRect)
		{
			var width = inRect.width;
			var offsetY = 0.0f;

			ControlsBuilder.Begin(inRect);
			try
			{
				CaravanEventActive_MoodEffect = ControlsBuilder.CreateNumeric(
					ref offsetY,
					width,
					"SY_CMB.CaravanEventActive_MoodEffect".Translate(),
					"SY_CMB.TooltipCaravanEventActive_MoodEffect".Translate(),
					CaravanEventActive_MoodEffect,
					Default_CaravanEventActive_MoodEffect,
					nameof(CaravanEventActive_MoodEffect),
					0,
					1000f);

				CaravanTraveling_MoodEffect = ControlsBuilder.CreateNumeric(
					ref offsetY,
					width,
					"SY_CMB.CaravanTraveling_MoodEffect".Translate(),
					"SY_CMB.TooltipCaravanTraveling_MoodEffect".Translate(),
					CaravanTraveling_MoodEffect,
					Default_CaravanTraveling_MoodEffect,
					nameof(CaravanTraveling_MoodEffect),
					0,
					1000f);

				CaravanForming_MoodEffect = ControlsBuilder.CreateNumeric(
					ref offsetY,
					width,
					"SY_CMB.CaravanForming_MoodEffect".Translate(),
					"SY_CMB.TooltipCaravanForming_MoodEffect".Translate(),
					CaravanForming_MoodEffect,
					Default_CaravanForming_MoodEffect,
					nameof(CaravanForming_MoodEffect),
					0,
					1000f);

				CaravanEventSuccess_MoodEffect = ControlsBuilder.CreateNumeric(
					ref offsetY,
					width,
					"SY_CMB.CaravanEventSuccess_MoodEffect".Translate(),
					"SY_CMB.TooltipCaravanEventSuccess_MoodEffect".Translate(),
					CaravanEventSuccess_MoodEffect,
					Default_CaravanEventSuccess_MoodEffect,
					nameof(CaravanEventSuccess_MoodEffect),
					0,
					1000f);
				CaravanEventSuccess_DurationDays = ControlsBuilder.CreateNumeric(
					ref offsetY,
					width,
					"SY_CMB.CaravanEventSuccess_DurationDays".Translate(),
					"SY_CMB.TooltipCaravanEventSuccess_DurationDays".Translate(),
					CaravanEventSuccess_DurationDays,
					Default_CaravanEventSuccess_DurationDays,
					nameof(CaravanEventSuccess_DurationDays),
					0,
					60f);

				CaravanBattleWon_MoodEffect = ControlsBuilder.CreateNumeric(
					ref offsetY,
					width,
					"SY_CMB.CaravanBattleWon_MoodEffect".Translate(),
					"SY_CMB.TooltipCaravanBattleWon_MoodEffect".Translate(),
					CaravanBattleWon_MoodEffect,
					Default_CaravanBattleWon_MoodEffect,
					nameof(CaravanBattleWon_MoodEffect),
					0,
					1000f);
				CaravanBattleWon_DurationDays = ControlsBuilder.CreateNumeric(
					ref offsetY,
					width,
					"SY_CMB.CaravanBattleWon_DurationDays".Translate(),
					"SY_CMB.TooltipCaravanBattleWon_DurationDays".Translate(),
					CaravanBattleWon_DurationDays,
					Default_CaravanBattleWon_DurationDays,
					nameof(CaravanBattleWon_DurationDays),
					0,
					60f);
			}
			finally
			{
				ControlsBuilder.End(offsetY);
			}
		}
		#endregion

		#region OVERRIDES
		public override void ExposeData()
		{
			base.ExposeData();

			var floatValue = CaravanEventActive_MoodEffect;
			Scribe_Values.Look(ref floatValue, nameof(CaravanEventActive_MoodEffect), Default_CaravanEventActive_MoodEffect);
			CaravanEventActive_MoodEffect = floatValue;

			floatValue = CaravanTraveling_MoodEffect;
			Scribe_Values.Look(ref floatValue, nameof(CaravanTraveling_MoodEffect), Default_CaravanTraveling_MoodEffect);
			CaravanTraveling_MoodEffect = floatValue;

			floatValue = CaravanForming_MoodEffect;
			Scribe_Values.Look(ref floatValue, nameof(CaravanForming_MoodEffect), Default_CaravanForming_MoodEffect);
			CaravanForming_MoodEffect = floatValue;

			floatValue = CaravanEventSuccess_MoodEffect;
			Scribe_Values.Look(ref floatValue, nameof(CaravanEventSuccess_MoodEffect), Default_CaravanEventSuccess_MoodEffect);
			CaravanEventSuccess_MoodEffect = floatValue;
			floatValue = CaravanEventSuccess_DurationDays;
			Scribe_Values.Look(ref floatValue, nameof(CaravanEventSuccess_DurationDays), Default_CaravanEventSuccess_DurationDays);
			CaravanEventSuccess_DurationDays = floatValue;

			floatValue = CaravanBattleWon_MoodEffect;
			Scribe_Values.Look(ref floatValue, nameof(CaravanBattleWon_MoodEffect), Default_CaravanBattleWon_MoodEffect);
			CaravanBattleWon_MoodEffect = floatValue;
			floatValue = CaravanBattleWon_DurationDays;
			Scribe_Values.Look(ref floatValue, nameof(CaravanBattleWon_DurationDays), Default_CaravanBattleWon_DurationDays);
			CaravanBattleWon_DurationDays = floatValue;
		}
		#endregion
	}
}
