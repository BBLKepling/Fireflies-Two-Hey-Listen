using HarmonyLib;
using FirefliesTwoO;
using Verse.Sound;
using Verse;
using RimWorld;

namespace Fireflies_Two_Hey_Listen
{
    [HarmonyPatch(typeof(JobDriver_ChaseFireflies))]
    [HarmonyPatch("ExecuteChaseFirefliesTickAction")]
    class JobDriver_ChaseFireflies_ExecuteChaseFirefliesTickAction_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(ref int ___tickCounter, ref Pawn ___pawn)
        {
            if (___tickCounter != HeyListen_Settings.tickRate) return;
            Pawn pawn = ___pawn;
            InternalDefOf.BBLK_HeyListen.PlayOneShot(new TargetInfo(pawn.Position, pawn.Map));
            if (HeyListen_Settings.fireBite != 0 && Rand.Range(1, 101) <= HeyListen_Settings.fireBite) pawn.TryAttachFire(0.1f, pawn);
            if (HeyListen_Settings.flyBite == 0 || 
                Rand.Range(1, 101) > HeyListen_Settings.flyBite || 
                !(pawn.health.hediffSet.GetRandomNotMissingPart(DamageDefOf.Bite, depth: BodyPartDepth.Outside) is BodyPartRecord part) ||
                !(HediffMaker.MakeHediff(InternalDefOf.BBLK_Firefly_Bite, pawn, part) is Hediff hediff)) return;
            hediff.Severity = 0.1f;
            pawn.health.AddHediff(hediff);
        }
    }
}
