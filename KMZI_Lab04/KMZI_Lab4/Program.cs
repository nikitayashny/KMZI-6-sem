using System.Text;
using KMZI_Lab4;
internal class Program
{
    private static void Main(string[] args)
    {
        Vigener vegener = new Vigener();
        Port port = new Port();
        Console.OutputEncoding = Encoding.Unicode;

        String keyword = "yashny";
        String textE = "";
        String textD = "";

        //encrypt Vigener
        long OldTicks = DateTime.Now.Ticks;

        using (StreamReader sr = new StreamReader("../../../in.txt"))
        {
            textE = (sr.ReadToEnd());
        }
        using (StreamWriter sw = new StreamWriter("../../../Encode_Vigener.txt", false))
        {
            sw.WriteLine(vegener.Encode(textE, keyword));
        }

        long time_cipher = (DateTime.Now.Ticks - OldTicks) / 1000;
        Console.WriteLine("На шифрование Виженера затрачено " + time_cipher + " мс");

        //decrypt Vigener
        OldTicks = DateTime.Now.Ticks;

        using (StreamReader sr = new StreamReader("../../../Encode_Vigener.txt"))
        {
            textD = (sr.ReadToEnd());
        }
        using (StreamWriter sw = new StreamWriter("../../../Decode_Vigener.txt", false))
        {
            sw.WriteLine(vegener.Decode(textD, keyword));
        }

        long time_decipher = (DateTime.Now.Ticks - OldTicks) / 1000;
        Console.WriteLine("На дешифрование Виженера затрачено " + time_decipher + " мс");

        // encrypt Port
        OldTicks = DateTime.Now.Ticks;

        using (StreamWriter sw = new StreamWriter("../../../Encode_Port.txt", false))
        {
            sw.WriteLine(port.Encode(textE));
        }

        time_cipher = (DateTime.Now.Ticks - OldTicks) / 1000;
        Console.WriteLine("На шифрование Порты затрачено " + time_cipher + " мс");

        //decrypt Port
        OldTicks = DateTime.Now.Ticks;

        using (StreamReader sr = new StreamReader("../../../Encode_Port.txt"))
        {
            textD = (sr.ReadToEnd());
        }
        using (StreamWriter sw = new StreamWriter("../../../Decode_Port.txt", false))
        {
            sw.WriteLine(port.Decode(textD));
        }

        time_decipher = (DateTime.Now.Ticks - OldTicks) / 1000;
        Console.WriteLine("На дешифрование Порты затрачено " + time_decipher + " мс");
    }
}