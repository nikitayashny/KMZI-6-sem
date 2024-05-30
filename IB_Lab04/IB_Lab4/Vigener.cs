namespace IB_Lab04
{
    internal class Vigener
    {
        static char[] characters = new char[] { 'a','b','c','d','e','f','g','h','i','j',
                                                'k','l','m','n','o','p','q','r','s','t',
                                                'u','v','w','x','y','z','ä','ö','ü','ß',
                                                ' ',',','.','\"','!','?','0','1','2','3','4','5','6','7','8','9',':','-'};
        static int N = characters.Length;
        int[] colFx1 = new int[N];
        int[] colFx2 = new int[N];
        public string Encode(string input, string keyword)
        {
            string result = "";
            int keyword_index = 0;
            for (int i = 0; i < N; i++)                                               
                colFx1[i] = input.Where(el => el == characters[i]).Count();            
            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(characters, symbol) +
                    Array.IndexOf(characters, keyword[keyword_index])) % N;         
                result += characters[c];
                keyword_index++;
                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }
            return result;
        }
        public string Decode(string input, string keyword)
        {
            string result = "";
            int keyword_index = 0;
            for (int i = 0; i < N; i++)                                                
                colFx2[i] = input.Where(el => el == characters[i]).Count();        
            foreach (char symbol in input)
            {
                int p = (Array.IndexOf(characters, symbol) + N -
                    Array.IndexOf(characters, keyword[keyword_index])) % N;         
                result += characters[p];
                keyword_index++;
                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }
            return result;
        }
    }
}