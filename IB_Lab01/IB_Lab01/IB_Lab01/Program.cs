using IB_Lab01;
internal class Program
{
    private static void Main(string[] args)
    {
        var belarusianText = Entropy.ReadFromFile("belarusian.txt");
        var polishText = Entropy.ReadFromFile("polish.txt");
        var binaryText = Entropy.ReadFromFile("binary.txt");
        var myNameText = Entropy.ReadFromFile("myName.txt");
        var myNameASCIIText = Entropy.ReadFromFile("myNameASCII.txt");
        Console.WriteLine($"Entropy (belarusian): {Entropy.GetShannonEntropy(belarusianText)}");
        Console.WriteLine($"Entropy (polish): {Entropy.GetShannonEntropy(polishText)}");
        Console.WriteLine($"Entropy (binary): {Entropy.GetShannonEntropy(binaryText)}");
        Console.WriteLine("\nP = 0");
        Console.WriteLine($"Information Amount (belarusian): {Entropy.GetInformationAmount(belarusianText, myNameText)}");
        Console.WriteLine($"Information Amount (polish): {Entropy.GetInformationAmount(polishText, myNameText)}");
        Console.WriteLine($"Information Amount (ASCII): {Entropy.GetInformationAmount(binaryText, myNameASCIIText)}");
        Console.WriteLine("\nP = 0.1");
        Console.WriteLine($"Information Amount (belarusian): {Entropy.GetInformationAmount(belarusianText, myNameText, 0.1)}");
        Console.WriteLine($"Information Amount (polish): {Entropy.GetInformationAmount(polishText, myNameText, 0.1)}");
        Console.WriteLine($"Information Amount (ASCII): {Entropy.GetInformationAmount(binaryText, myNameASCIIText, 0.1)}");
        Console.WriteLine("\nP = 0.5");
        Console.WriteLine($"Information Amount (belarusian): {Entropy.GetInformationAmount(belarusianText, myNameText, 0.5)}");
        Console.WriteLine($"Information Amount (polish): {Entropy.GetInformationAmount(polishText, myNameText, 0.5)}");
        Console.WriteLine($"Information Amount (ASCII): {Entropy.GetInformationAmount(binaryText, myNameASCIIText, 0.5)}");
        Console.WriteLine("\nP = 1");
        Console.WriteLine($"Information Amount (belarusian): {Entropy.GetInformationAmount(belarusianText, myNameText, 1)}");
        Console.WriteLine($"Information Amount (polish): {Entropy.GetInformationAmount(polishText, myNameText, 1)}");
        Console.WriteLine($"Information Amount (ASCII): {Entropy.GetInformationAmount(binaryText, myNameASCIIText, 1)}");
    }
}