using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
namespace MutagenRemover
{
    public class HediffCompProperties_RemoveMutagen:CompProperties_Drug
    {
        public HediffCompProperties_RemoveMutagen()
        {
            compClass = typeof(HediffComp_RemMutagen);
        }
    }

    public class HediffComp_RemMutagen : CompDrug
    {
        public override void PostIngested(Pawn ingester)
        {
            if (ingester.health.hediffSet.HasHediff(HediffDefOf.StabiliserHigh)) //if stabilized
            {

                Hediff h = ingester.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.AcceleratorHigh);
                Remover(ingester, h);
                 h = ingester.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.StabiliserHigh);
                Remover(ingester, h);
                Messages.Message("Stabilized mutagen successfully removed",MessageTypeDefOf.NeutralEvent,true);
                //otherwise do nothing
            }
            else
            {
                Messages.Message("Mutagen not stabilized or not present", MessageTypeDefOf.NeutralEvent, true);
            }
            base.PostIngested(ingester);

        }

        private void Remover(Pawn ingester, Hediff h)
        {
            if (h != null)
            {
                ingester.health.RemoveHediff(h);
            }
            h = null;
        }
    }
   
}
