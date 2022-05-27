using System;
using Toletus.LiteNet2.ConsoleApp.LiteNet;

namespace Toletus.LiteNet2.ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Example App Toletus LiteNet2");
            Console.WriteLine("");

            while (true)
            {
                Console.WriteLine("Press ENTER to search for Toletus LiteNets2 or type the LiteNet2 IP, or type 9 then ENTER to exit:");

                var option = Console.ReadLine();

                if (option == "9") return;
                
                if (string.IsNullOrWhiteSpace(option)) 
                    LiteNetSearchMenu.Menu();
                else
                    MainMenu.Menu(option);
            }
        }
    }
}