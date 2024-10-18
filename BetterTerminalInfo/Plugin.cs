using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace BetterTerminalInfo;

[BepInPlugin(GUID, MODNAME, VERSION)]
public class Plugin : BasePlugin
{
    internal const string AUTHOR = "tru0067";
    internal const string MODNAME = "BetterTerminalInfo";
    internal const string GUID = AUTHOR + "." + MODNAME;
    internal const string VERSION = "1.0.0";

    public override void Load()
    {
        // Plugin startup logic
        Logger.SetupFromInit(this.Log);
        Logger.Info($"{MODNAME} is loading...");
        _ = Harmony.CreateAndPatchAll(typeof(Patch), GUID);
        Logger.Info($"{MODNAME} is loaded!");
    }
}