﻿using System.Text.RegularExpressions;
namespace IB_Lab15;
internal class Steganography
{
    static int hideLenght;
    const string fileNameContainer = @"C:\bstu_labs\labs-6-sem\ib\IB_Lab15\container.txt";
    const string fileNameContainerHidden = @"C:\bstu_labs\labs-6-sem\ib\IB_Lab15\container_hidden.txt";
    const string fileNameOpenText = @"C:\bstu_labs\labs-6-sem\ib\IB_Lab15\open_text.txt";
    public static void HideMessage(string message)
    {
        string container = File.ReadAllText(fileNameContainer);
        hideLenght = message.Length;
        string[] words = container.Split(' ');
        int messageBits = message.Length * 8;
        int containerWords = words.Length;
        if (messageBits > containerWords)
        {
            Console.WriteLine("Message is too long for this container");
            return;
        }
        string binaryMessage = "";
        foreach (char c in message)
        {
            string binaryChar = Convert.ToString(c, 2).PadLeft(8, '0');
            binaryMessage += binaryChar;
        }
        string[] modifiedWords = new string[containerWords];
        int currentBit = 0;
        for (int i = 0; i < containerWords; i++)
        {
            int spaceCount = i == containerWords - 1 ? 0 : 1;
            if (currentBit < binaryMessage.Length && binaryMessage[currentBit] == '1')
            {
                spaceCount++;
            }
            modifiedWords[i] = words[i] + new string(' ', spaceCount);
            currentBit++;
        }
        string newContainer = string.Join("", modifiedWords);
        Console.WriteLine("CONTAINER WITH HIDDEN MESSAGE:");
        Console.WriteLine(newContainer.Replace(" ", "_"));
        File.WriteAllText(fileNameContainerHidden, newContainer);
    }
    public static void ShowMessage()
    {
        string container = File.ReadAllText(fileNameContainerHidden);
        string pattern = @"(\S+\s*)";
        MatchCollection matches = Regex.Matches(container, pattern);
        string[] words = matches.Select(x => x.Value).ToArray();
        string binaryMessage = "";
        foreach (string word in words)
        {
            int spaceCount = word.Length - word.TrimEnd().Length;
            if (spaceCount == 1)
            {
                binaryMessage += "0";
            }
            else if (spaceCount == 2)
            {
                binaryMessage += "1";
            }
        }
        int messageLength = binaryMessage.Length / 8;
        string message = "";
        for (int i = 0; i < messageLength; i++)
        {
            string binaryChar = binaryMessage.Substring(i * 8, 8);
            char c = (char)Convert.ToByte(binaryChar, 2);
            message += c;
        }
        message = message[..hideLenght];
        Console.WriteLine("\nOPEN TEXT:");
        Console.WriteLine(message);
        File.WriteAllText(fileNameOpenText, message);
    }
}