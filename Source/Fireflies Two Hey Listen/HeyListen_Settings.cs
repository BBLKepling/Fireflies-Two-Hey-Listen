using UnityEngine;
using Verse;

namespace Fireflies_Two_Hey_Listen
{
    public class HeyListen_Settings : ModSettings
    {
        public static int tickRate = 60;
        public static int flyBite = 0;
        public static int fireBite = 0;
        public override void ExposeData()
        {
            Scribe_Values.Look(ref tickRate, "tickRate", 60);
            Scribe_Values.Look(ref flyBite, "flyBite", 0);
            Scribe_Values.Look(ref fireBite, "fireBite", 0);
            base.ExposeData();
        }
    }
    public class HeyListenMod : Mod
    {
        public HeyListenMod(ModContentPack content) : base(content)
        {
            GetSettings<HeyListen_Settings>();
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            HeyListen_Settings.tickRate = (int)listingStandard.SliderLabeled("BBLK_HeyListen_tickRate_Label".Translate() + " " + HeyListen_Settings.tickRate, HeyListen_Settings.tickRate, 30, 120, tooltip: "BBLK_HeyListen_tickRate_ToolTip".Translate());
            HeyListen_Settings.flyBite = (int)listingStandard.SliderLabeled("BBLK_HeyListen_flyBite_Label".Translate() + " " + HeyListen_Settings.flyBite + "%", HeyListen_Settings.flyBite, 0, 100, tooltip: "BBLK_HeyListen_flyBite_ToolTip".Translate());
            HeyListen_Settings.fireBite = (int)listingStandard.SliderLabeled("BBLK_HeyListen_fireBite_Label".Translate() + " " + HeyListen_Settings.fireBite + "%", HeyListen_Settings.fireBite, 0, 100, tooltip: "BBLK_HeyListen_fireBite_ToolTip".Translate());
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }
        public override string SettingsCategory() => "BBLK_HeyListenSettings".Translate();
    }
}
