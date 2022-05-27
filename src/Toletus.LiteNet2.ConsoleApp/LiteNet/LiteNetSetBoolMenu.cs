﻿using System;
using Humanizer;
using Toletus.LiteNet2.Base;
using Toletus.LiteNet2.Command.Enums;

namespace Toletus.LiteNet2.ConsoleApp.LiteNet
{
    internal class LiteNetSetBoolMenu
    {
        public static void Menu(LiteNet2BoardBase liteNet2, Commands command)
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine($"{command.Humanize(LetterCasing.Title)}:");
                Console.WriteLine($"     0 - False");
                Console.WriteLine($"     1 - True");
                Console.WriteLine($" ENTER - Return");

                var option = Console.ReadLine();

                if (string.IsNullOrEmpty(option) || "01".IndexOf(option, StringComparison.Ordinal) < 0) return;

                liteNet2.Send(command, int.Parse(option));

                Console.WriteLine($"The {command.Humanize(LetterCasing.LowerCase)} was setted as {int.Parse(option) == 1}");
            }
        }
    }
}