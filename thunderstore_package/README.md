# Better Terminal Info

Updates the `INFO` command and the initial terminal output to include the number of available extra commands.

This increases the discoverability of unique commands. Players are less incentivized to use the `COMMANDS` command on every terminal they encounter and are not as unduly punished for missing some objective text that tells them of the existence of a command.

### Known Issues
-   The extra command count does not update when a command is removed.
    -   This might be difficult to fix as how the game handles the removal of commands has been changed since R6's mono build. It is also not clear if this is desirable to fix as in some cases it may be useful to know that a terminal *used to* have a command, and the `COMMANDS` command will still correctly show all of the commands currently available.