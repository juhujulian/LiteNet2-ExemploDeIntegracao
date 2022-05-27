﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Humanizer;
using Toletus.Extensions;
using Toletus.SM25.Command;
using Toletus.SM25.Command.Enums;

namespace Toletus.LiteNet2.ConsoleApp.FingerprintReader
{
    internal static class FingerprintReaderMenu
    {
        private static TcpClient _client;
        private static Thread _responseThread;

        public static void Menu(IPAddress ip)
        {
            Console.WriteLine($"Connecting to fingerprint reader...");

            _client = new TcpClient();
            _client.Connect(ip, 7879);

            StartResponseThread();

            Console.WriteLine("Connected!");

            var exit = false;
            while (!exit)
            {
                Console.WriteLine("");
                Console.WriteLine($"{nameof(FingerprintReaderMenu).Humanize(LetterCasing.Title)}:");
                Console.WriteLine($"    0 - {Commands.GetEmptyID.Humanize()}");
                Console.WriteLine($"    1 - {Commands.Enroll.Humanize()}");
                Console.WriteLine($"    2 - {Commands.ClearTemplate.Humanize()}");
                Console.WriteLine($"    3 - {Commands.ClearAllTemplate.Humanize()}");
                Console.WriteLine($"    4 - {Commands.GetTemplateStatus.Humanize()}");
                Console.WriteLine($"    5 - {Commands.FPCancel.Humanize()}");
                Console.WriteLine(" other - Return");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        new SendCommand(Commands.GetEmptyID).Send(_client);
                        break;
                    case "1":
                        Enroll();
                        break;
                    case "2":
                        ClearTemplate();
                        break;
                    case "3":
                        new SendCommand(Commands.ClearAllTemplate).Send(_client);
                        break;
                    case "4":
                        GetTemplateStatus();
                        break;
                    case "5":
                        new SendCommand(Commands.FPCancel).Send(_client);
                        break;
                    default:
                        exit = true;
                        break;
                }
            }

            _client.Close();
        }

        private static void Enroll()
        {
            var idBytes = GetTemplateId();
            new SendCommand(Commands.Enroll, idBytes).Send(_client);
        }

        private static void ClearTemplate()
        {
            var idBytes = GetTemplateId();
            new SendCommand(Commands.ClearTemplate, idBytes).Send(_client);
        }

        private static void GetTemplateStatus()
        {
            var idBytes = GetTemplateId();
            new SendCommand(Commands.GetTemplateStatus, idBytes).Send(_client);
        }

        private static byte[] GetTemplateId()
        {
            Console.WriteLine("");
            Console.WriteLine("Tempalte Id:");

            var id = int.Parse(Console.ReadLine());

            var idBytes = BitConverter.GetBytes(id).Take(2).ToArray();
            return idBytes;
        }

        private static void StartResponseThread()
        {
            if (_responseThread != null && _responseThread.IsAlive) return;

            _responseThread = new Thread(Response) { Name = "ResponseSM25", IsBackground = true };
            _responseThread.Start();
        }

        private static void Response()
        {
            var buffer = new byte[1024];

            try
            {
                var readBytes = 1;

                while (readBytes != 0)
                {
                    var stream = _client?.GetStream();

                    if (stream == null)
                        return;

                    readBytes = stream.Read(buffer, 0, buffer.Length);

                    var ret = buffer.Take(readBytes).ToArray();

                    ShowResponse(new ResponseCommand(ref ret));
                    Console.WriteLine(ret.ToHexString(" "));
                }
            }
            catch (ThreadAbortException e)
            {

            }
            catch (ObjectDisposedException e)
            {

            }
            catch (IOException e)
            {
                if (_client != null && _client.Connected) _client.Close();
            }
            catch (InvalidOperationException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void ShowResponse(ResponseCommand response)
        {
            Console.WriteLine($"{Environment.NewLine}Fingerprint Reader Response:{Environment.NewLine}{response.Command} {response.Data}{Environment.NewLine}{response}");
        }
    }
}