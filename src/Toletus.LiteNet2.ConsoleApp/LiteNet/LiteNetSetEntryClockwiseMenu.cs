using System;
using Humanizer;
using Toletus.LiteNet2.Base;
using Toletus.LiteNet2.Command.Enums;

namespace Toletus.LiteNet2.ConsoleApp.LiteNet
{
    internal class LiteNetSetEntryClockwiseMenu
    {
        public static void Menu(LiteNet2BoardBase liteNet2)
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine($"{Commands.SetEntryClockwise.Humanize()}:");
                Console.WriteLine($"     0 - True");
                Console.WriteLine($"     1 - False");
                Console.WriteLine($" other - Return");

                var entradaGiroSentidoHorario = Console.ReadLine();

                switch (entradaGiroSentidoHorario)
                {
                    case "0":
                        liteNet2.Send(Commands.GetEntryClockwise, BitConverter.GetBytes(0x01));
                        break;
                    case "1":
                        liteNet2.Send(Commands.GetEntryClockwise, BitConverter.GetBytes(0x00));
                        break;
                    default:
                        return;
                }
            }
        }
    }
}