# Better Terminal Info

Updates the `INFO` command and the initial terminal output to include the number of available extra commands.

This increases the discoverability of unique commands. Players are less incentivized to use the `COMMANDS` command on every terminal they encounter and are not as unduly punished for missing some objective text that tells them of the existence of a command.

You can find the dev feedback thread on the GTFO modding discord here: <https://discord.com/channels/782438773690597389/1256059163071615048/1256059163071615048>

### Known Issues
-   The extra command count does not update when a command is removed.
    -   This might be difficult to fix as how the game handles the removal of commands has been changed since R6's mono build. It is also not clear if this is desirable to fix as in some cases it may be useful to know that a terminal *used to* have a command, and the `COMMANDS` command will still correctly show all of the commands currently available.
-   The number of extra commands reported in the initial terminal output may be incorrect after checkpointing.
    -   This is because the mod does not try to update the initial terminal output if it detects that the terminal has already been used, and checkpointing may mean that terminal that was used prior to checkpointing but which hasn't been used since checkpointing may still be detected as having already been used.
    -   This is unlikely to be fixed.
