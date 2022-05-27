using System;

namespace Toletus.LiteNet1.ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Example App Toletus LiteNet1");
            Console.WriteLine("");

            while (true)
            {
                Console.WriteLine("Type the LiteNet1 IP, or type 9 then ENTER to exit:");

                var option = Console.ReadLine();

                if (option == "9") return;

                MainMenu.Menu(option);
            }
        }
    }
}