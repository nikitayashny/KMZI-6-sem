using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMZI_Lab3
{
    internal class Entropy
    {
        public static Dictionary<char, int> GetSymbolAppearances(string str)
        {
            var symbolAppearances = new Dictionary<char, int>();
            foreach (char c in str)
            {
                if (!symbolAppearances.ContainsKey(c))
                    symbolAppearances.Add(c, 1);
                else
                    symbolAppearances[c] += 1;
            }
            return symbolAppearances;
        }
        public static double GetShannonEntropy(string str)
        {
            var symbolAppearances = GetSymbolAppearances(str);
            var entropy = 0d;
            foreach (var item in symbolAppearances)
            {
                var P = (double)item.Value / str.Length;
                entropy -= P * Math.Log2(P);
            }
            return Math.Round(entropy, 3);
        }
        public static double GetHartleyEntropy(string str)
        {
            var symbolAppearances = GetSymbolAppearances(str);
            var entropy = Math.Log2(symbolAppearances.Count);
            return Math.Round(entropy, 3);
        }
        public static double GetAlphabetRedundancy(double Shannon, double Hartley)
        {
            return ((Hartley - Shannon) / Hartley) * 100;
        }
        public static string ReadFromFile(string fileName)
        {
            var pathToFolder = "../../../Alphabets/";
            var filePath = Path.Combine(pathToFolder, fileName);
            var text = "";
            using (var sr = new StreamReader(filePath))
                text = sr.ReadToEnd().ToLower();
            return text;
        }
    }
}
