# BetterTerminalInfo

For the thunderstore package README which contains an overview of the mod for
users see `thunderstore_package/README.md`.

This plugin overrides
`LG_ComputerTerminalCommandInterpreter.AddInitialTerminalOutput` to include the
number of extra available commands.
-   This method is called for both the initial terminal output and for the
    `INFO` command, so patching this one method patches both of those.

It additionally postfixes `LG_ComputerTerminalCommandInterpreter.AddCommand` to
refresh the initial terminal output if the terminal has not been used.
