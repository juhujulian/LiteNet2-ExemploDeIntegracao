using System;
using Humanizer;
using Toletus.LiteNet2.Base;
using Toletus.LiteNet2.Command.Enums;

namespace Toletus.LiteNet2.ConsoleApp.LiteNet
{
    internal class SetMenu
    {
        public static void Menu(LiteNet2BoardBase liteNet2)
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine($"{nameof(SetMenu).Humanize(LetterCasing.Title)}:");
                Console.WriteLine($"     0 - {Commands.SetFlowControl.Humanize()}");
                Console.WriteLine($"     1 - {Commands.SetFlowControlExtended.Humanize()}");
                Console.WriteLine($"     2 - {Commands.SetEntryClockwise.Humanize()}");
                Console.WriteLine($"     3 - {Commands.SetMenuPassword.Humanize()}");
                Console.WriteLine($"     4 - {Commands.SetMessageLine1.Humanize()}");
                Console.WriteLine($"     5 - {Commands.SetMessageLine2.Humanize()}");
                Console.WriteLine($"     6 - {Commands.SetBuzzerMute.Humanize()}");
                Console.WriteLine($"     7 - {Commands.SetShowCounters.Humanize()}");
                Console.WriteLine($"     8 - {Commands.ResetCounters.Humanize()}");
                Console.WriteLine($" other - Return");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        LiteNetSetFlowControlMenu.Menu(liteNet2);
                        break;
                    case "1":
                        LiteNetSetFlowControlExtendedMenu.Menu(liteNet2);
                        break;
                    case "2":
                        LiteNetSetEntryClockwiseMenu.Menu(liteNet2);
                        break;
                    case "3":
                        LiteNetSetPasswordMenu.Menu(liteNet2);
                        break;
                    case "4":
                        LiteNetSetMessageMenu.Menu(liteNet2, Commands.SetMessageLine1);
                        break;
                    case "5":
                        LiteNetSetMessageMenu.Menu(liteNet2, Commands.SetMessageLine2);
                        break;
                    case "6":
                        LiteNetSetBoolMenu.Menu(liteNet2, Commands.SetBuzzerMute);
                        break;
                    case "7":
                        LiteNetSetBoolMenu.Menu(liteNet2, Commands.SetShowCounters);
                        break;
                    case "8":
                        liteNet2.Send(Commands.ResetCounters);
                        break;
                    default:
                        return;
                }
            }
        }
    }
}