using System.Security.Cryptography;
namespace IB_Lab12;
class RSACypher
{
    public static void GenerateRSAKeys(out byte[] publicKey, out byte[] privateKey)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            publicKey = rsa.ExportRSAPublicKey();
            privateKey = rsa.ExportRSAPrivateKey();
        }
    }
    public static byte[] CreateRSASignature(byte[] data, byte[] privateKey)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportRSAPrivateKey(privateKey, out _);
            return rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }
    }
    public static bool VerifyRSASignature(byte[] data, byte[] signature, byte[] publicKey)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportRSAPublicKey(publicKey, out _);
            return rsa.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }
    }
}