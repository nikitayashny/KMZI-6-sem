using System.Text;
namespace IB_Lab08;

public class CypherHelper
{
    const string pathToFolder = "../../../Texts/";
    const string fileNameOpen = "open_text.txt";
    const string fileNameEncrypt = "encrypt_rc4.txt";
    const string fileNameDecrypt = "decrypt_rc4.txt";
    public static bool AreRelativelyPrime(long a, long b)
    {
        while (b != 0)
        {
            var remainder = a % b;
            a = b;
            b = remainder;
        }
        return a == 1;
    }
    public static bool WriteToFile(byte[] text, string fileName = fileNameEncrypt)
    {
        var filePath = Path.Combine(pathToFolder, fileName);
        try
        {
            File.WriteAllBytes(filePath, text);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
    public static byte[] ReadFromFile(string fileName = fileNameDecrypt)
    {
        var filePath = Path.Combine(pathToFolder, fileName);
        return File.ReadAllBytes(filePath);
    }
    public static byte[] GetOpenText() => ReadFromFile(fileNameOpen);
    public static byte[] GetBytes(string str) => Encoding.UTF8.GetBytes(str);
    public static string GetString(byte[] bytes) => Encoding.UTF8.GetString(bytes);
}