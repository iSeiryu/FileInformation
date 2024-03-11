﻿using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

namespace FileInformation.Cli.Commands;
internal sealed class Fu : Command<Fu.Settings> {
    public sealed class Settings : CommandSettings {
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings) {
        var face =
            """
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣤⠤⠴⠶⠖⠛⠛⠒⠒⠒⣒⠚⠛⣷⣿⣾⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣤⣤⣤⣶⣿⣭⣥⣄⣀⣀⣀⡀⠀⠀⠀⢀⣾⣫⣤⣾⡿⠋⠀⠙⠛⢦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣾⡿⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠓⠲⣾⣯⣿⣿⣭⡶⠷⠀⠀⠀⠀⠙⢷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣴⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡆⠀⣾⢸⣿⣿⣿⠏⠉⠀⠀⠀⠀⠀⠀⠀⠀⢻⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡶⣻⣿⠋⠁⠀⠀⠀⠀⠀⠞⢁⣠⠄⠀⠀⠀⠀⠀⣿⣧⣸⢷⣿⣯⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠴⣫⣿⠟⠀⠀⠀⠀⠀⠀⠀⠀⠚⠋⢀⣤⣀⡤⠞⠃⢠⣿⣿⣿⣿⣿⠏⣿⠃⠀⠀⣠⣠⣀⣀⣀⣀⠀⠀⠀⠀⠹⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⢀⣀⣀⣘⣻⣿⣿⣁⡀⠀⠀⠀⠀⠀⠀⠀⣀⡤⠶⠋⠉⠉⠀⠀⠀⣾⣿⣿⣿⣿⣿⢸⠟⠀⢀⡴⠛⠁⠀⠀⢈⣙⣶⣄⡀⠀⠀⠙⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⢀⣾⡿⠋⠉⠛⠿⣿⣿⣷⣦⣤⣄⠀⠉⠁⠀⠀⠀⠀⠀⡀⢸⣿⣿⣿⣿⣿⡏⠈⠀⣴⠋⠀⠀⠀⠀⠀⢸⠉⠁⠙⢿⣆⠀⠀⠸⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⢀⣠⣾⡿⠋⠀⠀⠀⠀⠀⠀⠈⠙⠛⢯⣿⣿⣤⠀⠀⠀⠀⠀⠀⢳⡀⠉⣿⣿⣿⠸⠇⢠⡾⠃⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠈⢻⣷⡀⠀⠸⣯⠻⣆⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⢠⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣄⠀⠸⡇⠀⢦⠀⠀⢳⡀⢻⣷⡟⠀⢰⡟⠀⠀⠀⠀⠀⠀⠀⠀⠸⣷⣄⣀⣠⡼⠃⠻⣆⠀⢹⣇⠘⢧⠀⠀⠀⠀⠀⠀
            ⠀⠀⢀⣾⡿⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⡤⠤⠤⠤⢤⣌⢿⣷⣄⠹⡆⠈⢷⠀⠘⢧⠀⣿⡇⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣆⠀⠻⣄⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠚⣹⡇⠀⠀⠀⠀⠀⠀⣤⠞⠋⠀⠀⠀⠀⠀⠀⠘⢿⡻⣿⣆⠀⠀⠀⢷⡀⠀⠀⠹⠇⠀⢸⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⡇⠀⢻⣷⡄⠀⠀⠀⠀⠀
            ⠀⠀⢠⣿⠁⠀⠀⠀⠀⣴⠾⠷⠶⣦⠀⠀⠀⠀⠀⠀⠀⠀⠻⣄⡙⠻⣶⠀⠈⠁⠀⠀⠀⠀⠀⠈⢿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣧⠀⠀⢻⡽⣆⠀⠀⠀⠀
            ⣴⠀⣼⠟⠀⠀⠀⠀⣼⠃⠀⠀⠀⠹⣆⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠙⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡿⠀⠀⠈⣷⡙⣆⠀⠀⠀
            ⣿⣼⡟⠀⠀⠀⠀⠀⢿⡀⠀⠀⠀⢠⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳⣤⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⠟⠁⠀⠀⠀⠘⣧⣹⡀⠀⠀
            ⣿⣿⠃⠀⠀⠀⠀⠀⢸⡧⠤⠤⠶⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣸⠋⠀⣀⣤⠶⠋⠉⠉⠉⠙⣿⠟⠛⠳⢶⣍⠻⠶⠶⣶⠶⣒⣒⣲⣖⣚⣋⡀⠀⠀⠀⠀⠀⠀⠘⣿⡇⠀⠀
            ⣿⡟⠀⠀⠀⠀⠀⠀⢹⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⡾⠁⣠⣾⠟⢷⣄⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⣩⠟⠶⣤⣌⡁⠀⠀⠉⠓⠲⠦⣀⠀⠀⠀⠀⠀⠀⠘⣿⡇⠀⠀
            ⣿⠁⠀⠀⠀⠀⠀⠀⠈⢷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⠋⢀⣼⠟⠁⠀⠀⢽⣦⣄⡀⠀⠀⣿⠓⢦⣤⣼⠋⠀⠀⠀⠈⠙⠶⣾⠲⢦⣤⡀⠈⠳⣤⡀⠀⠀⠀⠀⠹⣿⠀⠀
            ⣿⠀⡿⠀⠀⠀⠀⢀⠀⠈⠻⣦⡀⠀⠀⠀⠀⠀⠀⣀⡴⠟⠁⢠⡟⡇⠀⠀⠀⠀⠀⢻⡀⠙⠳⢤⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢦⡀⠀⠙⠶⠀⠀⠀⠀⢹⣧⠀
            ⣿⣿⡇⠀⠀⠀⠀⠈⠳⣄⡀⠈⠙⠷⠶⠶⠶⠶⠞⠋⠀⠀⠀⣸⡷⢧⣄⡀⠀⠀⠀⢠⡇⠀⠀⠀⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣆⠀⠀⠀⠀⠀⠀⠀⣿⠀
            ⣿⣿⡇⠀⠀⠀⠀⠀⠀⠈⠙⠛⠒⢦⣤⣀⠀⠀⠀⣠⠀⠀⠀⣿⠀⠀⠙⣯⠉⠉⠉⠙⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣦⠀⠀⠀⠀⠀⠀⣿⠀
            ⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⠃⠀⠀⠀⣿⣠⠴⠶⠾⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⠶⣄⡀⠀⠀⠀⠀⠀⠀⠀⠈⣧⠀⠀⠀⠀⠀⣿⠀
            ⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠃⠀⠀⠀⠀⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⠶⠋⠁⠀⠈⣷⠀⠀⠀⠀⠀⠀⠀⠀⠸⡇⠀⠀⠀⠀⣿⠀
            ⠸⣿⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⠾⠋⠙⠲⠶⠋⠁⠀⠀⠀⠀⠀⣿⠀⠀⡾⠛⠳⣤⡀⠀⢰⡇⠀⠀⠀⠀⣿⠀
            ⠀⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⢀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⣀⡠⠶⣶⡿⢦⡀⡇⠀⠀⠀⠙⣦⣸⠇⠀⠀⠀⠀⣿⠀
            ⠀⠸⣿⣹⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⠀⠀⠀⠀⣼⠃⠀⠀⠀⠀⠀⠀⠀⠀⣼⠃⠀⠀⠀⠲⠶⠶⢶⣶⣶⣾⠉⢁⣴⠋⠀⠀⠹⣿⡀⠀⠀⠀⣀⡿⠀⠀⠀⠀⠀⣿⠀
            ⠀⠀⢻⣷⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⡟⠀⠀⠀⣰⠏⠀⠀⠀⠀⠀⠀⠀⠀⣾⠏⠀⠀⠀⠀⠀⢀⣴⠏⠁⠀⠸⣶⡏⢁⣠⣤⣤⣤⣾⣿⣿⣤⣴⠟⠁⠀⠀⠀⠀⠀⣿⠀
            ⠀⠀⠈⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⢿⠁⠀⠀⢠⡟⠀⠀⠀⠀⠀⠀⠀⠀⢠⡏⠀⠀⠀⡀⠀⢀⡼⠃⠀⠀⢀⣤⠾⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡞
            ⠀⠀⠀⢿⣻⣿⠀⠀⠀⠀⠀⠀⠀⠀⠐⡾⠺⠀⠀⢠⡾⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣇⡴⠛⠉⢻⣆⡾⠁⢠⡴⠖⠋⢁⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⠁
            ⠀⠀⠀⠈⢿⣿⣧⠀⠀⠀⠀⠀⠀⠀⢰⡇⠀⠀⠀⡾⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⠏⠀⠀⠀⠀⣩⡴⠞⠉⠀⣠⠞⠉⢉⡽⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣶⣿⣇⠀
            ⠀⠀⠀⠀⠈⢻⣿⣦⡀⠀⠀⠀⠀⠀⠈⠣⡄⠀⠀⡇⠀⢀⣤⠶⠛⢧⣀⠀⠀⣸⠋⠀⠀⠀⣠⠞⠋⠀⠀⣠⠞⠁⢠⠔⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣷⣿⠋⠀
            ⠀⠀⠀⠀⢀⡈⣿⡙⢿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢷⣏⣁⠀⠀⠀⢉⣙⢾⣁⣀⣀⣴⠞⠁⠀⠀⠀⣸⠇⠀⠰⠋⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⡿⠋⠀⠀
            ⠀⠀⠀⠀⠀⠙⢻⣿⢿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠛⠲⢶⣭⣤⣤⡤⠟⠛⠁⠀⠀⠀⠀⣠⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⠇⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⢿⣆⠀⠙⠿⣷⣤⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⠉⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠘⣿⡀⠀⠀⠀⠉⠻⣿⣶⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⣿⠃⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠉⠁⠀⠀⠀⠀⠀⠀⠉⠛⠷⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣴⡾⠛⠁⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⢷⣤⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣠⣤⣤⣤⣤⣤⣤⡤⠴⠖⠛⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠛⠛⠿⠶⢦⣤⣤⣤⣤⣤⠤⠴⠿⡿⡛⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            """;

        AnsiConsole.Write(face);

        return 1;
    }
}
