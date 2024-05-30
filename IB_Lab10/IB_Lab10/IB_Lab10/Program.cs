using System.Numerics;
using System.Security.Cryptography;
using IB_Lab10;

internal class Program
{
    private static void Main(string[] args)
    {
        const string fileNameEncryptRSA = "encrypt_rsa.txt";
        const string fileNameDecryptRSA = "decrypt_rsa.txt";
        const string fileNameEncryptElGamal = "encrypt_el_gamal.txt";
        const string fileNameDecryptElGamal = "decrypt_el_gamal.txt";
        const string pathToFolder = "../../../Texts/";
        const string fileNameOpen = "open_text.txt";
        var openText = CypherHelper.GetOpenText();
        RSAParameters publicKey;
        RSAParameters privateKey;
        using (var rsa = new RSACryptoServiceProvider(4096))
        {
            publicKey = rsa.ExportParameters(false);
            privateKey = rsa.ExportParameters(true);
        }
        var encryptedTextRSA = RSACypher.Encrypt(openText, publicKey);
        var decryptedTextRSA = RSACypher.Decrypt(encryptedTextRSA, privateKey);
        CypherHelper.WriteToFile(encryptedTextRSA, fileNameEncryptRSA);
        CypherHelper.WriteToFile(decryptedTextRSA, fileNameDecryptRSA);
        int p = ElGamalCypher.Search_p();
        int x = new Random().Next(1, p - 1);                       
        BigInteger y = BigInteger.Pow(ElGamalCypher.g_main, x) % p; 
        string text = File.ReadAllText(Path.Combine(pathToFolder, fileNameOpen));
        List<BigInteger> array_cipher_text = ElGamalCypher.Cipher(text, p, y);
        using (StreamWriter writer = new(Path.Combine(pathToFolder, fileNameEncryptElGamal)))
        {
            for (int i = 0; i != text.Length; i++)
            {
                writer.Write((char)ElGamalCypher.a);
                writer.Write((char)array_cipher_text[i]);
            }
        }
        using (StreamWriter writer = new(Path.Combine(pathToFolder, fileNameDecryptElGamal)))
            writer.Write(ElGamalCypher.Cipher_RAZ(text.Length, array_cipher_text, x, p));
        RSACypher.FirstTask();
    }
}