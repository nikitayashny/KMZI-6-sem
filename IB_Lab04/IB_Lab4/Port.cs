namespace IB_Lab04
{
    internal class Port
    {
        static char[] characters = new char[] { 'a','b','c','d','e','f','g','h','i','j',
                                                'k','l','m','n','o','p','q','r','s','t',
                                                'u','v','w','x','y','z','ä','ö','ü','ß',
                                                ' ' };
        static int N = characters.Length;
        public string Encode(string text)
        {
            int[,] matrix = new int[N, N];
            int count = 1;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = count;
                    count++;
                }
            }
            string encryptedText = "";
            if (text.Length % 2 != 0)
                text += " ";
            for (int i = 0; i < text.Length; i += 2)
            {
                char firstChar = text[i];
                char secondChar = text[i + 1];
                int firstIndex = Array.IndexOf(characters, firstChar);
                if (firstIndex == -1)
                    firstIndex = 0;
                int secondIndex = Array.IndexOf(characters, secondChar);
                if (secondIndex == -1)
                    secondIndex = 0;
                int firstNumber = matrix[firstIndex, secondIndex];
                int secondNumber = matrix[secondIndex, firstIndex];
                encryptedText += firstNumber.ToString("D3") + secondNumber.ToString("D3");
            }
            return encryptedText;
        }
        public string Decode(string encryptedText)
        {
            int[,] matrix = new int[N, N];
            int count = 1;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = count;
                    count++;
                }
            }
            string decryptedText = "";
            for (int i = 0; i < encryptedText.Length; i += 6)
            {
                if (i + 6 <= encryptedText.Length)
                {
                    string part = encryptedText.Substring(i, 6);
                    int firstNumber = int.Parse(part.Substring(0, 3));
                    int secondNumber = int.Parse(part.Substring(3, 3));
                    int firstIndex = -1;
                    int secondIndex = -1;
                    for (int j = 0; j < N; j++)
                    {
                        for (int k = 0; k < N; k++)
                        {
                            if (matrix[j, k] == firstNumber)
                            {
                                firstIndex = j;
                                break;
                            }
                        }
                        if (firstIndex != -1)
                            break;
                    }
                    for (int j = 0; j < N; j++)
                    {
                        for (int k = 0; k < N; k++)
                        {
                            if (matrix[k, j] == secondNumber)
                            {
                                secondIndex = k;
                                break;
                            }
                        }
                        if (secondIndex != -1)
                            break;
                    }
                    char firstChar = (firstIndex != -1) ? characters[firstIndex] : ' ';
                    char secondChar = (secondIndex != -1) ? characters[secondIndex] : ' ';
                    decryptedText += firstChar.ToString() + secondChar.ToString();
                }
            }
            return decryptedText;
        }
    }
}