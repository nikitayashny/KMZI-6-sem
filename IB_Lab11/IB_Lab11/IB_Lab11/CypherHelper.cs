namespace IB_Lab11;

public class CypherHelper
{
    const string pathToFolder = "../../../Texts/";
    const string fileNameOpen = "open_text.txt";
    public static bool WriteToFile(string text, string fileName)
    {
        var filePath = Path.Combine(pathToFolder, fileName);
        try
        {
            File.WriteAllText(filePath, text);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
    public static string ReadFromFile(string fileName)
    {
        var filePath = Path.Combine(pathToFolder, fileName);
        return File.ReadAllText(filePath);
    }
    public static string GetOpenText() => ReadFromFile(fileNameOpen);
}