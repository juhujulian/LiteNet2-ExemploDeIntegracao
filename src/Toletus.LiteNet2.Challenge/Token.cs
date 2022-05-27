using System;

namespace Toletus.LiteNet2.Challenge
{
    public class Token
    {
        public static byte[] Get(byte[] ch)
        {
            var token = BitConverter.GetBytes(Key.Token(ch));

            return token;
        }
    }
}