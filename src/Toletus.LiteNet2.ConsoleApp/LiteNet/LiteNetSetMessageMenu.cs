using System;
using System.Text;
using Humanizer;
using Toletus.LiteNet2.Base;
using Toletus.LiteNet2.Command.Enums;
using ToletusExtensions = Toletus.Extensions.StringExtensions;

namespace Toletus.LiteNet2.ConsoleApp.LiteNet
{
    internal class LiteNetSetMessageMenu
    {
        public static void Menu(LiteNet2BoardBase liteNet2, Commands command)
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine($"{command.Humanize(LetterCasing.Title)}:");
                Console.WriteLine($"     Type the new {command.Humanize(LetterCasing.LowerCase)} (16 characters)");
                Console.WriteLine($" ENTER - Return");

                var option = Console.ReadLine();

                if (string.IsNullOrEmpty(option)) return;

                option = ToletusExtensions.Truncate(option, 16);

                liteNet2.Send(command, Encoding.ASCII.GetBytes(option));

                Console.WriteLine($"The message was setted");
            }
        }
    }
}