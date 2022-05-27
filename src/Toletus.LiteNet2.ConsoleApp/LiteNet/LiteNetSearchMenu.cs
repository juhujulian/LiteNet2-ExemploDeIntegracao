using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Toletus.LiteNet2.Base.Util;

namespace Toletus.LiteNet2.ConsoleApp.LiteNet
{
    internal class LiteNetSearchMenu
    {
        public static void Menu()
        {
            var network = SearchNertworkInterfacesAndChoose();

            if (network == null) return;

            var liteNets2 = LiteNetUtil.Search(network.Value.Value);

            Console.WriteLine("LiteNets:");

            if (liteNets2.Count == 0)
                Console.WriteLine($"Cant't found LiteNet2 at {network.Value.Key}");
            else
                foreach (var item in liteNets2)
                    Console.WriteLine(item);

            Console.WriteLine("");
        }

        private static KeyValuePair<string, IPAddress>? SearchNertworkInterfacesAndChoose()
        {
            var networks = NetworkInterfaceUtil.GetNetworkInterfaces();

            Console.WriteLine("Choose a network interface:");

            for (var i = 0; i < networks.Count; i++)
                Console.WriteLine($"     {i + 1} - {networks.ElementAt(i).Key}");

            Console.WriteLine(" other - Return");

            var option = Console.ReadLine();

            if (string.IsNullOrEmpty(option) || int.Parse(option) >= networks.Count) return null;

            return networks.ElementAt(int.Parse(option) - 1);
        }
    }
}