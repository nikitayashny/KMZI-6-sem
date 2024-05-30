namespace IB_Lab01;
public class Entropy
{
    public static Dictionary<char, int> GetSymbolAppearances(string inputString)
    {
        var symbolAppearances = new Dictionary<char, int>();
        foreach (char symbol in inputString)
        {
            if (!symbolAppearances.ContainsKey(symbol))
                symbolAppearances.Add(symbol, 1);
            else
                symbolAppearances[symbol] += 1;
        }
        return symbolAppearances;
    }
    public static double GetShannonEntropy(string inputString)
    {
        var symbolAppearances = GetSymbolAppearances(inputString);
        var entropy = 0d;
        foreach (var kvp in symbolAppearances)
        {
            var probability = (double)kvp.Value / inputString.Length;
            entropy -= probability * Math.Log2(probability);
        }
        return Math.Round(entropy, 3);
    }
    public static double GetInformationAmount(string inputAlphabet, string inputString)
    {
        if (IsBinaryAlphabet(inputAlphabet))
            return inputString.Length;
        var informationAmount = GetShannonEntropy(inputAlphabet) * inputString.Length;
        return Math.Round(informationAmount, 3);
    }
    public static double GetEffectiveEntropy(string inputAlphabet, double probability)
    {
        var complementProbability = 1 - probability;
        if (IsBinaryAlphabet(inputAlphabet) && (probability == 0 || complementProbability == 0))
            return 1;
        if (!IsBinaryAlphabet(inputAlphabet) && probability == 1)
            return 0;
        return 1 - (-probability * Math.Log2(probability) - complementProbability * Math.Log2(complementProbability));
    }
    public static double GetInformationAmount(string inputAlphabet, string inputString, double probability)
    {
        var informationAmount = GetEffectiveEntropy(inputAlphabet, probability) * inputString.Length;
        return Math.Round(informationAmount, 3);
    }
    private static bool IsBinaryAlphabet(string alphabet) => GetSymbolAppearances(alphabet).Count == 2;
    public static string ReadFromFile(string inputFileName)
    {
        var pathToFolder = "../../../Alphabets/";
        var filePath = Path.Combine(pathToFolder, inputFileName);
        var text = "";
        using (var sr = new StreamReader(filePath))
            text = sr.ReadToEnd().ToLower();
        return text;
    }
}