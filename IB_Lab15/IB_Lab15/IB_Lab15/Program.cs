namespace IB_Lab15
{
    public class Program
    {
        public static void Main()
        {
            var openText = "qw";
            Steganography.HideMessage(openText);
            Steganography.ShowMessage();
        }
    }
}