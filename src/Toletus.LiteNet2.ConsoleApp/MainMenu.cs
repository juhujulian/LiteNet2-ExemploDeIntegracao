using System;
using System.Net;
using Humanizer;
using Toletus.LiteNet2.Base;
using Toletus.LiteNet2.Command;
using Toletus.LiteNet2.ConsoleApp.FingerprintReader;
using Toletus.LiteNet2.ConsoleApp.LiteNet;

namespace Toletus.LiteNet2.ConsoleApp
{
    internal static class MainMenu
    {
        public static void Menu(string ipString)
        {
            var ip = IPAddress.Parse(ipString);

            Console.WriteLine("Connecting to LiteNet2...");

            var liteNet2 = new LiteNet2BoardBase(ip);
            liteNet2.OnResponse += LiteNet2_OnResponse;

            liteNet2.Connect();

            Console.WriteLine("Connected!");

            var exit = false;
            while (!exit)
            {
                Console.WriteLine("");
                Console.WriteLine($"{nameof(MainMenu).Humanize(LetterCasing.Title)}:");
                Console.WriteLine($"     0 - {nameof(SetMenu).Humanize(LetterCasing.Title)}");
                Console.WriteLine($"     1 - {nameof(GetMenu).Humanize(LetterCasing.Title)}");
                Console.WriteLine($"     2 - {nameof(ReleaseMenu).Humanize(LetterCasing.Title)}");
                Console.WriteLine($"     3 - {nameof(FingerprintReaderMenu).Humanize(LetterCasing.Title)}");
                Console.WriteLine($" other - Exit");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "0":
                        SetMenu.Menu(liteNet2);
                        break;
                    case "1":
                        GetMenu.Menu(liteNet2);
                        break;
                    case "2":
                        ReleaseMenu.Menu(liteNet2);
                        break;
                    case "3":
                        FingerprintReaderMenu.Menu(ip);
                        break;
                    default:
                        exit = true;
                        break;
                }
            }

            liteNet2.Close();
        }

        private static void LiteNet2_OnResponse(ResponseCommand responseCommand)
        {
            Console.WriteLine($"{Environment.NewLine}LiteNet2 Response: {responseCommand}]");

            if (responseCommand.Identification != null)
                Console.WriteLine($"{Environment.NewLine}LiteNet2 Identification: {responseCommand.Identification} {responseCommand.Identification.EmbededTemplate}");
        }
    }
}