using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace KMZI_Lab3
{
    public class Conv
    {
        public static string ConvertToBase64(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            string base64String = Convert.ToBase64String(bytes);
            return base64String;
        }

        public static byte[] ConvertToASCII(string str)
        {
            byte[] buffer = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                buffer[i] = (byte)str[i];
            }

            return buffer;
        }
        public static byte[] ConvertStringToByteArray(string inputString)
        {
            byte[] result = new byte[inputString.Length];

            for (int i = 0; i < inputString.Length; i++)
            {
                char c = inputString[i];
                result[i] = (byte)GetBase64CharValue(c);
            }

            return result;
        }

        private static int GetBase64CharValue(char c)
        {
            if (c >= 'A' && c <= 'Z')
                return c - 'A';
            if (c >= 'a' && c <= 'z')
                return c - 'a' + 26;
            if (c >= '0' && c <= '9')
                return c - '0' + 52;
            if (c == '+')
                return 62;
            if (c == '/')
                return 63;

            return -1;
        }
    }
}
