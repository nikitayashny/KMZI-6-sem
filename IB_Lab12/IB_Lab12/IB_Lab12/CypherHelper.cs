using System.Numerics;
using System.Text;
namespace IB_Lab12;
public class CypherHelper
{
    const string pathToFolder = "../../../Texts/";
    const string fileNameOpen = "open_text.txt";
    const string fileNameEncrypt = "encrypt.txt";
    const string fileNameDecrypt = "decrypt.txt";
    public static bool WriteToFile(byte[] text, string fileName = fileNameEncrypt)
    {
        var filePath = Path.Combine(pathToFolder, fileName);
        try
        {
            File.WriteAllText(filePath, BitConverter.ToString(text));
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
    public static void WriteToFile(List<BigInteger> numbers, string fileName = fileNameEncrypt)
    {
        using (var writer = new StreamWriter(Path.Combine(pathToFolder, fileName)))
        {
            foreach (BigInteger number in numbers)
                writer.Write(number.ToString() + " ");
        }
    }
    public static byte[] GetOpenText() => ReadFromFile(fileNameOpen);
    public static byte[] GetBytes(string str) => Encoding.UTF8.GetBytes(str);
    public static string GetString(byte[] bytes) => Encoding.UTF8.GetString(bytes);
    public static string ReverseString(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}