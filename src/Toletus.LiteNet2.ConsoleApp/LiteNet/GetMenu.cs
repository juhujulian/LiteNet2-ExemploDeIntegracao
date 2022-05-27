using System;
using Humanizer;
using Toletus.LiteNet2.Base;
using Toletus.LiteNet2.Command.Enums;

namespace Toletus.LiteNet2.ConsoleApp.LiteNet
{
    internal class GetMenu
    {
        public static void Menu(LiteNet2BoardBase liteNet2)
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine($"{nameof(GetMenu).Humanize(LetterCasing.Title)}:");
                Console.WriteLine($"     0 - {Commands.GetBuzzerMute.Humanize()}");
                Console.WriteLine($"     1 - {Commands.GetFlowControl.Humanize()}");
                Console.WriteLine($"     2 - {Commands.GetFlowControlExtended.Humanize()}");
                Console.WriteLine($"     3 - {Commands.GetEntryClockwise.Humanize()}");
                Console.WriteLine($"     4 - {Commands.GetReleaseDuration.Humanize()}");
                Console.WriteLine($"     5 - {Commands.GetId.Humanize()}");
                Console.WriteLine($"     6 - {Commands.GetMac.Humanize()}");
                Console.WriteLine($"     7 - {Commands.GetFirmwareVersion.Humanize()}");
                Console.WriteLine($"     8 - {Commands.GetMenuPassword.Humanize()}");
                Console.WriteLine($"     9 - {Commands.GetMessageLine1.Humanize()}");
                Console.WriteLine($"    10 - {Commands.GetMessageLine2.Humanize()}");
                Console.WriteLine($"    11 - {Commands.GetShowCounters.Humanize()}");
                Console.WriteLine($"    12 - {Commands.GetBuzzerMute.Humanize()}");
                Console.WriteLine($" other - Return");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        liteNet2.Send(Commands.GetBuzzerMute);
                        break;
                    case "1":
                        liteNet2.Send(Commands.GetFlowControl);
                        break;
                    case "2":
                        liteNet2.Send(Commands.GetFlowControlExtended);
                        break;
                    case "3":
                        liteNet2.Send(Commands.GetEntryClockwise);
                        break;
                    case "4":
                        liteNet2.Send(Commands.GetReleaseDuration);
                        break;
                    case "5":
                        liteNet2.Send(Commands.GetId);
                        break;
                    case "6":
                        liteNet2.Send(Commands.GetMac);
                        break;
                    case "7":
                        liteNet2.Send(Commands.GetFirmwareVersion);
                        break;
                    case "8":
                        liteNet2.Send(Commands.GetMenuPassword);
                        break;
                    case "9":
                        liteNet2.Send(Commands.GetMessageLine1);
                        break;
                    case "10":
                        liteNet2.Send(Commands.GetMessageLine2);
                        break;
                    case "11":
                        liteNet2.Send(Commands.GetShowCounters);
                        break;
                    case "12":
                        liteNet2.Send(Commands.GetBuzzerMute);
                        break;
                    default:
                        return;
                }
            }
        }
    }
}