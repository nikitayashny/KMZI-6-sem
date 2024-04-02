using System.Text;

namespace KMZI_Lab3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string polish = Entropy.ReadFromFile("polish.txt");
            string base64 = Conv.ConvertToBase64(polish);

            Console.WriteLine($"Shannon Entropy of Language (polish):      {Entropy.GetShannonEntropy(polish)}");
            Console.WriteLine($"Shannon Entropy of Language (base64):      {Entropy.GetShannonEntropy(base64)}");
            Console.WriteLine($"\nHartley Entropy of Language (polish):      {Entropy.GetHartleyEntropy(polish)}");
            Console.WriteLine($"Hartley Entropy of Language (base64):      {Entropy.GetHartleyEntropy(base64)}");
            Console.WriteLine($"\nAlphabet Redundancy of Language (polish):      {Entropy.GetAlphabetRedundancy(Entropy.GetShannonEntropy(polish), Entropy.GetHartleyEntropy(polish))}");
            Console.WriteLine($"Alphabet Redundancy of Language (base64):      {Entropy.GetAlphabetRedundancy(Entropy.GetShannonEntropy(base64), Entropy.GetHartleyEntropy(base64))}");

            string name = "yashny";
            string surname = "nikita";

            byte[] bufferNameASCII = Conv.ConvertToASCII(name);
            byte[] bufferSurnameASCII = Conv.ConvertToASCII(surname);

            string nameBase64 = Conv.ConvertToBase64(name);  
            string surnameBase64 = Conv.ConvertToBase64(surname);

            byte[] bufferNameBase64 = Conv.ConvertStringToByteArray(nameBase64);
            byte[] bufferSurnameBase64 = Conv.ConvertStringToByteArray(surnameBase64);

            byte[] resultASCII = XOR.XorBuffers(bufferNameASCII, bufferSurnameASCII);
            byte[] resultBase64 = XOR.XorBuffers(bufferNameBase64, bufferSurnameBase64);

            Console.Write("\nXOR ASCII: ");
            foreach (byte b in resultASCII ) Console.Write(b + " ");
            Console.Write("\nXOR Base64: "); 
            foreach (byte b in resultBase64) Console.Write(b + " ");
            Console.WriteLine();
        }
    }
}