using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMZI_Lab3
{
    internal class XOR
    {
        public static byte[] XorBuffers(byte[] a, byte[] b)
        {
            int length = a.Length > b.Length ? a.Length : b.Length;

            if (a.Length < length)
            {
                byte[] resizedA = new byte[length];
                for (int i = 0; i < a.Length; i++)
                {
                    resizedA[i] = a[i];
                }
                a = resizedA;
            }

            if (b.Length < length)
            {
                byte[] resizedB = new byte[length];
                for (int i = 0; i < b.Length; i++)
                {
                    resizedB[i] = b[i];
                }
                b = resizedB;
            }

            byte[] result = new byte[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = (byte)(a[i] ^ b[i]);
            }

            return result;
        }
    }
}
