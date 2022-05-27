using System;
using Humanizer;
using Toletus.LiteNet2.Base;
using Toletus.LiteNet2.Command.Enums;

namespace Toletus.LiteNet2.ConsoleApp.LiteNet
{
    internal class ReleaseMenu
    {
        public static void Menu(LiteNet2BoardBase liteNet2)
        {
            while (true)
            {

                Console.WriteLine("");
                Console.WriteLine($"{nameof(ReleaseMenu).Humanize(LetterCasing.Title)}:");
                Console.WriteLine($"     0 - {Commands.ReleaseEntry.Humanize()}");
                Console.WriteLine($"     1 - {Commands.ReleaseExit.Humanize()}");
                Console.WriteLine($" other - Return");

                var liberar = Console.ReadLine();

                switch (liberar)
                {
                    case "0":
                        liteNet2.Send(Commands.ReleaseEntry);
                        break;
                    case "1":
                        liteNet2.Send(Commands.ReleaseExit);
                        break;
                    default:
                        return;
                }
            }
        }
    }
}