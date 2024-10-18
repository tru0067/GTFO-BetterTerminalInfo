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

## Contributing

Change the target r2modman profile in
`BetterTerminalInfo/BetterTerminalInfo.csproj` to your desired development
profile.

In order to prevent git from trying to include this change you can run:
```sh
git update-index --assume-unchanged BetterTerminalInfo/BetterTerminalInfo.csproj
```

Note that this will mean that any actual legitimate changes to this file won't
be noticed, you'll have to add those manually.

Also, don't forget to change the *Active solution configutation* to *Release*
in *Build > Configuration Manager*.
