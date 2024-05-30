namespace IB_Lab06;

public class Enigma
{
    const string alphabetOpen = "abcdefghijklmnopqrstuvwxyz";
    Dictionary<char, char> alphabetReflector;
    int length = alphabetOpen.Length;
    string alphabetLeftRotor = "ajdksiruxblhwtmcqgznpyfvoe";
    string alphabetMiddleRotor = "leyjvcnixwpbqmdrtakzgfuhos";
    string alphabetRightRotor = "fkqhtlxocbjspdzramewniuygv";
    int rotorRightCurrentPostition = 0;
    int rotorMiddleCurrentPostition = 0;
    int rotorLeftCurrentPostition = 0;
    int rotorRightTotalOffsets = 0;
    int rotorMiddleTotalOffsets = 0;
    int rotorLeftTotalOffsets = 0;
    int rotorRightFullRotations = 0;
    int rotorMiddleFullRotations = 0;
    int rotorLeftFullRotations = 0;
    int rotorRightStep = 2;
    int rotorMiddleStep = 2;
    int rotorLeftStep = 1;
    public Enigma(int rightRotorPosition, int middleRotorPosition, int leftRotorPosition)
    {
        if (rightRotorPosition >= 0 && rightRotorPosition < length &&
            middleRotorPosition >= 0 && middleRotorPosition < length &&
            leftRotorPosition >= 0 && leftRotorPosition < length)
        {
            rotorRightCurrentPostition = rightRotorPosition;
            rotorMiddleCurrentPostition = middleRotorPosition;
            rotorLeftCurrentPostition = leftRotorPosition;
        }
        else
        {
            throw new Exception($"Rotors positions must be between 0 and {length - 1}");
        }
        alphabetReflector = FillTheRelector();
    }
    public char[] Encrypt(char[] openText)
    {
        rotorRightTotalOffsets = rotorRightCurrentPostition;
        rotorMiddleTotalOffsets = rotorMiddleCurrentPostition;
        rotorLeftTotalOffsets = rotorLeftCurrentPostition;
        var sb = new System.Text.StringBuilder();
        foreach (char letter in openText)
        {
            if (alphabetOpen.Contains(letter))
            {
                var letterAfterRightRotor = EncryptWithRotor(letter, alphabetOpen, alphabetRightRotor, rotorRightCurrentPostition);
                var letterAfterMiddleRotor = EncryptWithRotor(letterAfterRightRotor, alphabetOpen, alphabetMiddleRotor, rotorMiddleCurrentPostition);
                var letterAfterLeftRotor = EncryptWithRotor(letterAfterMiddleRotor, alphabetOpen, alphabetLeftRotor, rotorLeftCurrentPostition);
                var letterAfterReflector = EncryptWithReflector(letterAfterLeftRotor);
                var letterAfterLeftRotorBackwards = EncryptWithRotor(letterAfterReflector, alphabetLeftRotor, alphabetOpen, rotorLeftCurrentPostition);
                var letterAfterMiddleRotorBackwards = EncryptWithRotor(letterAfterLeftRotorBackwards, alphabetMiddleRotor, alphabetOpen, rotorMiddleCurrentPostition);
                var letterAfterRightRotorBackwards = EncryptWithRotor(letterAfterMiddleRotorBackwards, alphabetRightRotor, alphabetOpen, rotorRightCurrentPostition);
                rotorRightTotalOffsets += rotorRightStep;
                rotorRightCurrentPostition = rotorRightTotalOffsets % length;  
                if (rotorRightTotalOffsets / length > 0)
                {
                    rotorRightFullRotations = rotorRightTotalOffsets / length;   
                    rotorMiddleTotalOffsets = rotorRightFullRotations * rotorMiddleStep;   
                    rotorMiddleCurrentPostition = rotorMiddleTotalOffsets % length;    
                }
                if (rotorMiddleTotalOffsets / length > 0)   
                {
                    rotorMiddleFullRotations = rotorMiddleTotalOffsets / length;    
                    rotorLeftTotalOffsets = rotorMiddleFullRotations * rotorLeftStep; 
                    rotorLeftCurrentPostition = rotorLeftTotalOffsets % length;     
                }
                if (rotorLeftTotalOffsets / length > 0)    
                    rotorLeftFullRotations = rotorLeftTotalOffsets / length;  
                sb.Append(letterAfterRightRotorBackwards);
            }
            else
                sb.Append(letter);
        }
        return sb.ToString().ToCharArray();
    }
    public char[] Decrypt(char[] openText)
    {
        rotorRightTotalOffsets = rotorRightCurrentPostition;
        rotorMiddleTotalOffsets = rotorMiddleCurrentPostition;
        rotorLeftTotalOffsets = rotorLeftCurrentPostition;
        var sb = new System.Text.StringBuilder();
        foreach (char letter in openText)
        {
            if (alphabetOpen.Contains(letter))
            {
                var letterAfterRightRotor = DecryptWithRotor(letter, alphabetOpen, alphabetRightRotor, rotorRightCurrentPostition);
                var letterAfterMiddleRotor = DecryptWithRotor(letterAfterRightRotor, alphabetOpen, alphabetMiddleRotor, rotorMiddleCurrentPostition);
                var letterAfterLeftRotor = DecryptWithRotor(letterAfterMiddleRotor, alphabetOpen, alphabetLeftRotor, rotorLeftCurrentPostition);
                var letterAfterReflector = EncryptWithReflector(letterAfterLeftRotor);
                var letterAfterLeftRotorBackwards = DecryptWithRotor(letterAfterReflector, alphabetLeftRotor, alphabetOpen, rotorLeftCurrentPostition);
                var letterAfterMiddleRotorBackwards = DecryptWithRotor(letterAfterLeftRotorBackwards, alphabetMiddleRotor, alphabetOpen, rotorMiddleCurrentPostition);
                var letterAfterRightRotorBackwards = DecryptWithRotor(letterAfterMiddleRotorBackwards, alphabetRightRotor, alphabetOpen, rotorRightCurrentPostition);
                rotorRightTotalOffsets += rotorRightStep;
                rotorRightCurrentPostition = rotorRightTotalOffsets % length;
                if (rotorRightTotalOffsets / length > 0)
                {
                    rotorRightFullRotations = rotorRightTotalOffsets / length;
                    rotorMiddleTotalOffsets = rotorRightFullRotations * rotorMiddleStep;
                    rotorMiddleCurrentPostition = rotorMiddleTotalOffsets % length;
                }
                if (rotorMiddleTotalOffsets / length > 0)
                {
                    rotorMiddleFullRotations = rotorMiddleTotalOffsets / length;
                    rotorLeftTotalOffsets = rotorMiddleFullRotations * rotorLeftStep;
                    rotorLeftCurrentPostition = rotorLeftTotalOffsets % length;
                }
                if (rotorLeftTotalOffsets / length > 0)
                    rotorLeftFullRotations = rotorLeftTotalOffsets / length;
                sb.Append(letterAfterRightRotorBackwards);
            }
            else
                sb.Append(letter);
        }
        return sb.ToString().ToCharArray();
    }
    private char EncryptWithRotor(char letter, string alphabet, string alphabetEncryption, int offset)
    {
        var index = alphabet.IndexOf(letter);
        var indexEncrypted = (index + offset) % length;
        var letterEncrypted = alphabetEncryption[indexEncrypted];
        return letterEncrypted;
    }
    private char DecryptWithRotor(char letter, string alphabet, string alphabetEncryption, int offset)
    {
        var index = alphabet.IndexOf(letter);
        var indexEncrypted = (index - offset + length) % length;
        var letterEncrypted = alphabetEncryption[indexEncrypted];
        return letterEncrypted;
    }
    private char EncryptWithReflector(char letter)
    {
        if (alphabetReflector.ContainsKey(letter))
            return alphabetReflector[letter];
        else if (alphabetReflector.ContainsValue(letter))
            return alphabetReflector.FirstOrDefault(x => x.Value == letter).Key;
        else
            return letter;
    }
    private Dictionary<char, char> FillTheRelector() => new Dictionary<char, char>
    {
        { 'a', 'f' }, { 'b', 'v' }, { 'c', 'p' }, { 'd', 'j' },  { 'e', 'i' },
        { 'g', 'o' }, { 'h', 'y' }, { 'k', 'r' }, { 'l', 'z' }, { 'm', 'x' },
        { 'n', 'w' }, { 't', 'q' }, { 's', 'u' }
    };
}