using RimWorld;
using Verse;

namespace Fireflies_Two_Hey_Listen
{
    [DefOf]
    public static class InternalDefOf
    {
        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }

        public static SoundDef BBLK_HeyListen;
        public static HediffDef BBLK_Firefly_Bite;
    }
}
