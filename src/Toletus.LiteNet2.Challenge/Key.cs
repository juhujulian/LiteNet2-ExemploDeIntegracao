using System;

namespace Toletus.LiteNet2.Challenge
{
    public class Key
    {
        /**
        * a = a + b
        */
        private static byte Add(byte[] a, byte[] b, int len)
        {

            int carry = 0;
            int i;
            for (i = 0; i < len; i++)
            {
                carry += a[i] + b[i];
                a[i] = (byte)carry;
                carry = carry >> 8;
            }
            return (byte)carry;
        }

        /**
         * return true if a >= b
         * */
        private static bool GE(byte[] a, byte[] b, int len)
        {
            int i;

            for (i = len; i-- > 0;)
            {
                if (a[i] > b[i]) return true;
                if (a[i] < b[i]) return false;
            }
            return true;
        }

        /**
         * return a - b
         */
        private static byte Sub(byte[] a, byte[] b, int len)
        {
            int carry = 0;
            int i;
            for (i = 0; i < len; i++)
            {
                carry = a[i] - (carry + b[i]);
                a[i] = (byte)carry;
                carry = (carry >> 8) & 1;
            }
            return (byte)carry;
        }

        /**
         * return a*b mod m
         */
        private static void ModMult(byte[] a, byte[] b, byte[] m, byte[] r, int len)
        {
            int i;
            Array.Clear(r, 0, len);
            for (i = len; i-- > 0;)
            {
                //r = 2*r  + a
                byte bm;
                for (bm = 0x80; bm > 0; bm = (byte)(bm >> 1))
                {
                    byte c = Add(r, r, len);
                    if (c != 0 || GE(r, m, len)) Sub(r, m, len);
                    if ((b[i] & bm) != 0)
                    {
                        c = Add(r, a, len);
                        if (c != 0 || GE(r, m, len)) Sub(r, m, len);
                    }
                }
            }
        }

        private static void ModExp(byte[] b, byte[] e, byte[] m, byte[] r, byte[] t, int len)
        {
            int i;
            Array.Clear(r, 0, len);
            r[0] = 1;//r = 1;
            for (i = len; i-- > 0;)
            {
                byte bm;
                for (bm = 0x80; bm > 0; bm = (byte)(bm >> 1))
                {
                    ModMult(r, r, m, t, len);//t <= r^2 (mod m)

                    if ((e[i] & bm) != 0)
                    {
                        ModMult(t, b, m, r, len);
                        //printf("sqr mult\n");
                    }
                    else
                    {
                        Array.Copy(t, r, len);
                    }
                }
            }
        }

        public static uint Token(byte[] cbr)
        {
            byte[] n = { 0xd1, 0xfe, 0x5a, 0xb7, 0x12, 0xb7, 0xf1, 0x96, 0xf7, 0x00, 0x36, 0xb5, 0x87, 0x37, 0x8a, 0x29 };
            byte[] d = { 0xf1, 0xa8, 0x04, 0x8a, 0x3c, 0x6f, 0xe0, 0x4a, 0x3c, 0xcd, 0x16, 0x3e, 0x38, 0xd6, 0x34, 0x02 };
            byte[] r = new byte[16];
            byte[] t = new byte[16];

            if (cbr.Length != 16) return 0;
            ModExp(cbr, d, n, r, t, 16);
            return BitConverter.ToUInt32(r, 0);
        }

        //public static void test()
        //{
        //    byte[] c = {0x2f, 0x76, 0x95, 0x97, 0x7f, 0xf0, 0x12, 0xae, 0x85, 0x71, 0xfc, 0x9f, 0x0c, 0xf5, 0xb2, 0x17};
        //    UInt32 r = 0xbc4b4158;

        //    if (Token(c) == r)
        //        Console.WriteLine("test pass");
        //}
    }
}