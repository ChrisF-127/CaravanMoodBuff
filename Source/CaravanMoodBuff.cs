using HugsLib.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace CaravanMoodBuff
{
	public class CaravanMoodBuff : HugsLib.ModBase
	{
		private SettingHandle<float> _caravanEventActive_MoodEffect;

		private SettingHandle<float> _caravanTraveling_MoodEffect;

		private SettingHandle<float> _caravanEventSuccess_MoodEffect;
		private SettingHandle<float> _caravanEventSuccess_DurationDays;

		private SettingHandle<float> _caravanBattleWon_MoodEffect;
		private SettingHandle<float> _caravanBattleWon_DurationDays;

		public override string ModIdentifier => "CaravanMoodBuff";

		public override void DefsLoaded()
		{
			_caravanEventActive_MoodEffect = Settings.GetHandle(
				"caravaneventactive_moodeffect",
				"SY_CMB.CaravanEventActive_MoodEffect".Translate(),
				"SY_CMB.TooltipCaravanEventActive_MoodEffect".Translate(),
				ThoughtDefOfCaravanMoodBuff.CaravanEventActive.stages[0].baseMoodEffect,
				Validators.FloatRangeValidator(0f, 1000f));
			_caravanEventActive_MoodEffect.ValueChanged += (value) =>
				ThoughtDefOfCaravanMoodBuff.CaravanEventActive.stages[0].baseMoodEffect = (SettingHandle<float>)value;
			ThoughtDefOfCaravanMoodBuff.CaravanEventActive.stages[0].baseMoodEffect = _caravanEventActive_MoodEffect;


			_caravanTraveling_MoodEffect = Settings.GetHandle(
				"caravantraveling_moodeffect",
				"SY_CMB.CaravanTraveling_MoodEffect".Translate(),
				"SY_CMB.TooltipCaravanTraveling_MoodEffect".Translate(),
				ThoughtDefOfCaravanMoodBuff.CaravanTraveling.stages[0].baseMoodEffect,
				Validators.FloatRangeValidator(0f, 1000f));
			_caravanTraveling_MoodEffect.ValueChanged += (value) =>
				ThoughtDefOfCaravanMoodBuff.CaravanTraveling.stages[0].baseMoodEffect = (SettingHandle<float>)value;
			ThoughtDefOfCaravanMoodBuff.CaravanTraveling.stages[0].baseMoodEffect = _caravanTraveling_MoodEffect;


			_caravanEventSuccess_MoodEffect = Settings.GetHandle(
				"caravaneventsuccess_moodeffect",
				"SY_CMB.CaravanEventSuccess_MoodEffect".Translate(),
				"SY_CMB.TooltipCaravanEventSuccess_MoodEffect".Translate(),
				ThoughtDefOfCaravanMoodBuff.CaravanEventSuccess.stages[0].baseMoodEffect,
				Validators.FloatRangeValidator(0f, 1000f));
			_caravanEventSuccess_MoodEffect.ValueChanged += (value) =>
				ThoughtDefOfCaravanMoodBuff.CaravanEventSuccess.stages[0].baseMoodEffect = (SettingHandle<float>)value;
			ThoughtDefOfCaravanMoodBuff.CaravanEventSuccess.stages[0].baseMoodEffect = _caravanEventSuccess_MoodEffect;

			_caravanEventSuccess_DurationDays = Settings.GetHandle(
				"caravaneventsuccess_durationdays",
				"SY_CMB.CaravanEventSuccess_DurationDays".Translate(),
				"SY_CMB.TooltipCaravanEventSuccess_DurationDays".Translate(),
				ThoughtDefOfCaravanMoodBuff.CaravanEventSuccess.durationDays,
				Validators.FloatRangeValidator(0f, 60f));
			_caravanEventSuccess_DurationDays.ValueChanged += (value) =>
				ThoughtDefOfCaravanMoodBuff.CaravanEventSuccess.durationDays = (SettingHandle<float>)value;
			ThoughtDefOfCaravanMoodBuff.CaravanEventSuccess.durationDays = _caravanEventSuccess_DurationDays;


			_caravanBattleWon_MoodEffect = Settings.GetHandle(
				"caravanbattlewon_moodeffect",
				"SY_CMB.CaravanBattleWon_MoodEffect".Translate(),
				"SY_CMB.TooltipCaravanBattleWon_MoodEffect".Translate(),
				ThoughtDefOfCaravanMoodBuff.CaravanBattleWon.stages[0].baseMoodEffect,
				Validators.FloatRangeValidator(0f, 1000f));
			_caravanBattleWon_MoodEffect.ValueChanged += (value) =>
				ThoughtDefOfCaravanMoodBuff.CaravanBattleWon.stages[0].baseMoodEffect = (SettingHandle<float>)value;
			ThoughtDefOfCaravanMoodBuff.CaravanBattleWon.stages[0].baseMoodEffect = _caravanBattleWon_MoodEffect;

			_caravanBattleWon_DurationDays = Settings.GetHandle(
				"caravanbattlewon_durationdays",
				"SY_CMB.CaravanBattleWon_DurationDays".Translate(),
				"SY_CMB.TooltipCaravanBattleWon_DurationDays".Translate(),
				ThoughtDefOfCaravanMoodBuff.CaravanBattleWon.durationDays,
				Validators.FloatRangeValidator(0f, 60f));
			_caravanBattleWon_DurationDays.ValueChanged += (value) =>
				ThoughtDefOfCaravanMoodBuff.CaravanBattleWon.durationDays = (SettingHandle<float>)value;
			ThoughtDefOfCaravanMoodBuff.CaravanBattleWon.durationDays = _caravanBattleWon_DurationDays;
		}
	}
}
