using HarmonyLib;
using Verse;

namespace Fireflies_Two_Hey_Listen
{
    [StaticConstructorOnStartup]
    public static class HarmonyInit
    {
        static HarmonyInit()
        {
            Harmony harmonyInstance = new Harmony("BBLKepling.FirefliesTwoHeyListen");
            harmonyInstance.PatchAll();
        }
    }
}
