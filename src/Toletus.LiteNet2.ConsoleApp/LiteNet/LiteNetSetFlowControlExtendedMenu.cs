using System;
using Humanizer;
using Toletus.LiteNet2.Base;
using Toletus.LiteNet2.Command.Enums;

namespace Toletus.LiteNet2.ConsoleApp.LiteNet
{
    internal class LiteNetSetFlowControlExtendedMenu
    {
        public static void Menu(LiteNet2BoardBase liteNet2)
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine($"{Commands.SetFlowControlExtended}:");

                var enumLength = Enum.GetNames(typeof(ControlledFlowExtended)).Length;
                
                for (var i = 0; i < enumLength; i++)
                    Console.WriteLine($"     {i} - {((ControlledFlowExtended)i).Humanize()}");

                Console.WriteLine($" other - Return");

                var option = Console.ReadLine();

                if (string.IsNullOrEmpty(option) || !int.TryParse(option, out var flow)) return;

                if (flow >= enumLength) return;

                liteNet2.Send(Commands.SetFlowControlExtended, flow);
            }
        }
    }
}