namespace LuneLib.Utilities.Hashsets.Calamity;

[JITWhenModsEnabled("CalValEX")]
public static class CalEXSets
{
    #region Aquatic Npcs

    public static readonly HashSet<int> AquaticNPCs;

    static CalEXSets()
    {
        bool isCalValExLoaded = ModLoader.HasMod("CalValEX");
        AquaticNPCs = isCalValExLoaded ? CreateCalValExNpcSpecificTypes() : [];
    }

    private static HashSet<int> CreateCalValExNpcSpecificTypes() =>
    [
        #region CalValEX Mod NPCs

            #region Sulphurous Sea NPCs

                //acid rain specific
                ModContent.NPCType<Vaporofly>(),
                ModContent.NPCType<Orthobab>(),

            #endregion

            #region Layer4

                ModContent.NPCType<Isopod>(),

            #endregion

        #endregion
    ];

    #endregion
}