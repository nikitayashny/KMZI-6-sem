namespace IB_Lab05;

public class SwapHelper
{
    const string pathToFolder = "../../../Texts/";
    const string fileNameOpen = "open_text.txt";
    public static Dictionary<char, int> GetSymbolAppearances(char[] str)
    {
        var symbolAppearances = new Dictionary<char, int>();
        foreach (char c in str)
        {
            if (!symbolAppearances.ContainsKey(c))
                symbolAppearances.Add(c, 1);
            else
                symbolAppearances[c] += 1;
        }
        return symbolAppearances;
    }
    public static char[] ReadFromFile(string fileName)
    {
        var filePath = Path.Combine(pathToFolder, fileName);
        var text = "";
        using (var sr = new StreamReader(filePath))
            text = sr.ReadToEnd();
        return text.ToLower().ToCharArray();
    }
    public static bool WriteToFile(char[] text, string fileName)
    {
        var filePath = Path.Combine(pathToFolder, fileName);
        try
        {
            using (var sw = new StreamWriter(filePath))
                sw.WriteLine(text);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
    public static char[,] ConvertToTwoDimentionalArray(char[] array, int rows, int cols)
    {
        var length = array.Length;
        var result = new char[rows, cols];
        var index = 0;
        for (var i = 0; i < rows; ++i)
            for (var j = 0; j < cols && index < length; ++j)
            {
                result[i, j] = array[index];
                index++;
            }
        return result;
    }
    public static char[,] GetTableByColumns(char[,] inputArray)
    {
        var rows = inputArray.GetLength(0);
        var columns = inputArray.GetLength(1);
        var outputArray = new char[rows, columns];

        for (int j = columns - 1; j >= 0; j--)
            for (int i = 0; i < rows; i++)
                outputArray[i, j] = inputArray[i, j];
        return outputArray;
    }
    public static char[] ConvertToOneDimentionalArray(char[,] array) => array.Cast<char>().ToArray();
    public static char[] GetOpenText() => ReadFromFile(fileNameOpen);
    public static bool WriteToFile(char[,] text, string fileName) => WriteToFile(ConvertToOneDimentionalArray(text), fileName);
}