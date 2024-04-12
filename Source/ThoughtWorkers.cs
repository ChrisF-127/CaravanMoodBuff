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
				&& p.Map?.IsPlayerHome == false)
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
				&& p.ParentHolder is Caravan caravan && caravan.IsPlayerControlled)
				return ThoughtState.ActiveDefault;
			return ThoughtState.Inactive;
		}
	}
}
