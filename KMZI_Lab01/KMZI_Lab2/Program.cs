using KMZI_Lab2;

var belarusian = Entropy.ReadFromFile("belarusian.txt");
var polish = Entropy.ReadFromFile("polish.txt");
var binary = Entropy.ReadFromFile("binary.txt");
var myName = Entropy.ReadFromFile("myName.txt");
var myNameASCII = Entropy.ReadFromFile("myNameASCII.txt");


Console.WriteLine("\n==========================================");
Console.WriteLine($"Entropy of Language (belarusian):  {Entropy.GetShannonEntropy(belarusian)}");
Console.WriteLine($"Entropy of Language (polish):      {Entropy.GetShannonEntropy(polish)}");
Console.WriteLine($"Entropy of Language (binary):      {Entropy.GetShannonEntropy(binary)}");

Console.WriteLine("\n================  P = 0  =================");
Console.WriteLine($"Information Amount (belarusian):   {Entropy.GetInformationAmount(belarusian, myName)}");
Console.WriteLine($"Information Amount (polish):       {Entropy.GetInformationAmount(polish, myName)}");
Console.WriteLine($"Information Amount (ASCII):        {Entropy.GetInformationAmount(binary, myNameASCII)}");

Console.WriteLine("\n===============  P = 0.1  ================");
Console.WriteLine($"Information Amount (belarusian):   {Entropy.GetInformationAmount(belarusian, myName, 0.1)}");
Console.WriteLine($"Information Amount (polish):       {Entropy.GetInformationAmount(polish, myName, 0.1)}");
Console.WriteLine($"Information Amount (ASCII):        {Entropy.GetInformationAmount(binary, myNameASCII, 0.1)}");

Console.WriteLine("\n===============  P = 0.5  ================");
Console.WriteLine($"Information Amount (belarusian):   {Entropy.GetInformationAmount(belarusian, myName, 0.5)}");
Console.WriteLine($"Information Amount (polish):       {Entropy.GetInformationAmount(polish, myName, 0.5)}");
Console.WriteLine($"Information Amount (ASCII):        {Entropy.GetInformationAmount(binary, myNameASCII, 0.5)}");

Console.WriteLine("\n================  P = 1  =================");
Console.WriteLine($"Information Amount (belarusian):   {Entropy.GetInformationAmount(belarusian, myName, 1)}");
Console.WriteLine($"Information Amount (polish):       {Entropy.GetInformationAmount(polish, myName, 1)}");
Console.WriteLine($"Information Amount (ASCII):        {Entropy.GetInformationAmount(binary, myNameASCII, 1)}");
