﻿using IB_Lab05;

internal class Program
{
    private static void Main(string[] args)
    {
        var fileNameEncryptRoute = "encrypt_route.txt";
        var fileNameDecryptRoute = "decrypt_route.txt";
        var fileNameEncryptMultiple = "encrypt_multiple.txt";
        var fileNameDecryptMultiple = "decrypt_multiple.txt";
        var rows = 66;
        var cols = 66;
        SwapHelper.WriteToFile(Swap.EncryptRouteSwap(rows, cols), fileNameEncryptRoute);
        SwapHelper.WriteToFile(Swap.DecryptRouteSwap(rows, cols), fileNameDecryptRoute);
        var encryptedTableMultiple = Swap.EncryptMultiple("nikita", "yashny");
        var decryptedTableMultiple = Swap.DecryptMultiple("nikita", "yashny", encryptedTableMultiple);
        SwapHelper.WriteToFile(encryptedTableMultiple, fileNameEncryptMultiple);
        SwapHelper.WriteToFile(decryptedTableMultiple, fileNameDecryptMultiple);
    }
}