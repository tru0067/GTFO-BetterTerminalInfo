﻿using HarmonyLib;
using LevelGeneration;

namespace BetterTerminalInfo;

internal static class Patch
{
    [HarmonyPatch(
        typeof(LG_ComputerTerminalCommandInterpreter),
        nameof(LG_ComputerTerminalCommandInterpreter.AddInitialTerminalOutput)
    )]
    [HarmonyPrefix]
    public static bool AddBetterInitialTerminalOutput(
        LG_ComputerTerminalCommandInterpreter __instance)
    {
        // Count the number of extra commands.
        int commandsCount = 0;
        if (__instance.m_commandsPerEnum != null)
        {
            foreach (Il2CppSystem.Collections.Generic.KeyValuePair<TERM_Command, string> keyValuePair
                in __instance.m_commandsPerEnum)
            {
                switch (keyValuePair.Key)
                {
                    // Ignore the standard commands.
                    case TERM_Command.ShowList:
                    case TERM_Command.Query:
                    case TERM_Command.Ping:
                    case TERM_Command.ListLogs:
                    case TERM_Command.ReadLog:
                    case TERM_Command.Info:
                    case TERM_Command.Help:
                    case TERM_Command.Commands:
                    case TERM_Command.Cls:
                    case TERM_Command.Exit:
                    case TERM_Command.Start:
                        break;
                    default:
                        ++commandsCount;
                        break;
                }
            }
        }

        // Vanilla code (aside from `v0.50` change): {{{
        string itemKey = __instance.m_terminal.ItemKey;
        int count = __instance.m_terminal.GetLocalLogs().Count;
        __instance.AddOutput("", false);
        __instance.AddOutput("---------------------------------------------------------------", false);
        __instance.AddOutput("TERMINAL OS v0.50", false);
        __instance.AddOutput("---------------------------------------------------------------", false);
        if (__instance.m_terminal.SpawnNode != null)
        {
            string formattedText = __instance.m_terminal.SpawnNode.m_zone.NavInfo.GetFormattedText(LG_NavInfoFormat.Full_And_Number_With_Underscore);
            __instance.AddOutput("Welcome to <b>" + itemKey + "</b>, located in <b>" + formattedText + "</b>");
        }
        else
            __instance.AddOutput("Welcome to <b>" + itemKey + "</b>");
        // }}}
        // Only change on this line is the `false` to avoid an extra blank line:
        __instance.AddOutput(string.Format("There are {0} logs on this terminal", (object)count), false);
        // BetterInitialTerminalInfo addition:
        __instance.AddOutput(string.Format("There are {0} extra commands on this terminal", (object)commandsCount));
        // Vanilla code: {{{
        __instance.AddOutput("Type \"HELP\" to get help using the terminal.", false);
        __instance.AddOutput("Type \"COMMANDS\" to get a list of all available commands.", false);
        __instance.AddOutput("Press [ESC] to exit");
        // }}}

        return false;
    }
}