using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace BetterTerminalInfo;

[BepInPlugin("BetterTerminalInfo", "BetterTerminalInfo", "1.0.0")]
public class Plugin : BasePlugin
{
    public override void Load()
    {
        // Plugin startup logic
        _ = Harmony.CreateAndPatchAll(typeof(Patch), "tru0067.BetterTerminalInfo");
        Log.LogInfo("BetterTerminalInfo is loaded!");
    }
}