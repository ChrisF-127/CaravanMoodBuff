using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace CaravanMoodBuff
{
	public class ThoughtWorker_CaravanEvent : ThoughtWorker
	{
		public override ThoughtState CurrentStateInternal(Pawn p)
		{
			if (p?.IsColonist == true
				&& def.stages[0].baseMoodEffect != 0
				&& p.Map != null
				&& !p.Map.IsPlayerHome
				&& (!p.Map.IsPocketMap || p.Map.IsTempIncidentMap))
				return ThoughtState.ActiveDefault;
			return ThoughtState.Inactive;
		}
	}

	public class ThoughtWorker_CaravanTraveling : ThoughtWorker
	{
		public override ThoughtState CurrentStateInternal(Pawn p)
		{
			if (p?.IsColonist == true
				&& def.stages[0].baseMoodEffect != 0 
				&& p.IsPlayerControlledCaravanMember())
				return ThoughtState.ActiveDefault;
			return ThoughtState.Inactive;
		}
	}

	public class ThoughtWorker_CaravanForming : ThoughtWorker
	{
		public override ThoughtState CurrentStateInternal(Pawn p)
		{
			if (p?.IsColonist == true
				&& def.stages[0].baseMoodEffect != 0 
				&& p.IsFormingCaravan())
				return ThoughtState.ActiveDefault;
			return ThoughtState.Inactive;
		}
	}
}
