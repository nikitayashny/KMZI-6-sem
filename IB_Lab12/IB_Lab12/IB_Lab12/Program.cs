﻿using System.Diagnostics;
using System.Numerics;
using IB_Lab12;

internal class Program
{
    private static void Main(string[] args)
    {
        const string fileNameSignatureRSA = "signature_rsa.txt";
        const string fileNameSignatureElGamal = "signature_elgamal.txt";
        const string fileNameSignatureSchnorr = "signature_schnorr.txt";
        var openText = CypherHelper.GetOpenText();
        var stopWatchRSA = new Stopwatch();
        stopWatchRSA.Start();
        RSACypher.GenerateRSAKeys(out byte[] rsaPublicKey, out byte[] rsaPrivateKey);
        var rsaSignature = RSACypher.CreateRSASignature(openText, rsaPrivateKey);
        var rsaIsValid = RSACypher.VerifyRSASignature(openText, rsaSignature, rsaPublicKey);
        CypherHelper.WriteToFile(rsaSignature, fileNameSignatureRSA);
        stopWatchRSA.Stop();
        Console.WriteLine($"RSA signature:\t\t{stopWatchRSA.ElapsedTicks} ticks ({stopWatchRSA.ElapsedMilliseconds} ms)");
        Console.WriteLine($"Is valid RSA: \t\t{rsaIsValid}\n");
        var stopWatchElGamal = new Stopwatch();
        stopWatchElGamal.Start();
        int p = 2137;
        int g = 2127;
        int x = 1116;
        int k = 7;
        int H = 2119;
        var signatureElGamal = ElGamalCypher.GenerateElGamalSignature(p, g, x, k, H);
        var y = (int)BigInteger.ModPow(g, x, p);
        var elGamalIsValid = ElGamalCypher.VerifyElGamalSignature(p, g, y, H, signatureElGamal);
        CypherHelper.WriteToFile(signatureElGamal, fileNameSignatureElGamal);
        stopWatchElGamal.Stop();
        Console.WriteLine($"El-Gamal signature:\t{stopWatchElGamal.ElapsedTicks} ticks ({stopWatchElGamal.ElapsedMilliseconds} ms)");
        Console.WriteLine($"Is valid El-Gamal: \t{elGamalIsValid}\n");
        var stopWatchSchnorr = new Stopwatch();
        stopWatchSchnorr.Start();
        byte[] schnorrPublicKey;
        byte[] schnorrPrivateKey;
        SchnorrCypher.GenerateSchnorrKeys(out schnorrPublicKey, out schnorrPrivateKey);
        var signatureSchnorr = SchnorrCypher.CreateSchnorrSignature(openText, schnorrPrivateKey);
        var schnorrIsValid = SchnorrCypher.VerifySchnorrSignature(openText, signatureSchnorr, schnorrPublicKey);
        CypherHelper.WriteToFile(signatureSchnorr, fileNameSignatureSchnorr);
        stopWatchSchnorr.Stop();
        Console.WriteLine($"Schnorr signature:\t{stopWatchSchnorr.ElapsedTicks} ticks ({stopWatchSchnorr.ElapsedMilliseconds} ms)");
        Console.WriteLine($"Is valid Schnorr: \t{schnorrIsValid}");
    }
}