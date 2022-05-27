using System;
using System.Net.Sockets;
using Toletus.SM25.Command;

namespace Toletus.LiteNet2.ConsoleApp.FingerprintReader
{
    internal static class SendCommandExtensions
    {
        public static void Send(this SendCommand sendCommand, TcpClient client)
        {
            var stream = client?.GetStream();
            stream?.Write(sendCommand.Payload, 0, sendCommand.Payload.Length);
            Console.Write($"Fingerprint Reader Send:{Environment.NewLine}{sendCommand}");
        }
    }
}
