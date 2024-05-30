using System.Diagnostics;
using System.Numerics;
namespace IB_Lab10;

public class ElGamalCypher
{
    public static int g_main;
    public static BigInteger a;
    public static bool Search_g(int p, int g)
    {
        bool boolean = false;
        List<BigInteger> array_mod_number = new List<BigInteger>();
        BigInteger integer = ((BigInteger.Pow(g, 1)) % p);
        array_mod_number.Add(integer);
        for (int i = 2; i != p; i++)
        {
            integer = BigInteger.Pow(g, i) % p;
            for (int j = 0; j != i - 1; j++)
            {
                if (array_mod_number[j] == integer)
                {
                    g--;
                    array_mod_number.Clear();
                    i = 1;
                    integer = BigInteger.Pow(g, 1) % p;
                    array_mod_number.Add(integer);
                    break;
                }
                if ((j == i - 2) && (array_mod_number[j] != integer))
                    array_mod_number.Add(integer);
            }
        }
        g_main = g;
        boolean = true;
        return boolean;
    }
    public static int Search_p()
    {
        Random random = new Random();
        int p = 0;
        Boolean boolean = false;
        do
        {
            p = random.Next(2000, 2500);
            for (int i = 2; i != p; i++)
            {
                if (i == p - 1)
                {
                    boolean = Search_g(p, p - 1);
                    break;
                }
                if (p % i == 0) break;
            }
        }
        while (boolean == false);
        return p;
    }
    public static List<BigInteger> Cipher(string text, int p, BigInteger y)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        List<BigInteger> array = new List<BigInteger>();
        Random random = new Random();
        int k = random.Next(1, p - 1);
        for (int i = 0; i != text.Length; i++)
        {
            a = BigInteger.Pow(g_main, k) % p;
            array.Add((BigInteger.Pow(y, k) * (int)text[i]) % p);
        }
        stopWatch.Stop();
        Console.WriteLine($"ElGamal Encrypt:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return array;
    }
    public static string Cipher_RAZ(int length_text, List<BigInteger> array_number, int x, int p)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        string save_text = "";
        BigInteger integer;
        for (int i = 0; i != length_text; i++)
        {
            integer = (array_number[i] * (BigInteger.Pow(a, p - 1 - x))) % p;
            save_text += (char)integer;
        }
        stopWatch.Stop();
        Console.WriteLine($"ElGamal Decrypt:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return save_text;
    }
}