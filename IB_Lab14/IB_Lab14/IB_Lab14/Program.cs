namespace IB_Lab14
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fileNameOpen = @"C:\bstu_labs\labs-6-sem\ib\IB_Lab14\IB_Lab14\IB_Lab14\Images\sample.bmp";
            var fileNameEncryptByRows = @"C:\bstu_labs\labs-6-sem\ib\IB_Lab14\IB_Lab14\IB_Lab14\Images\ecnrypted_by_rows.bmp";
            var fileNameEncryptByColumns = @"C:\bstu_labs\labs-6-sem\ib\IB_Lab14\IB_Lab14\IB_Lab14\Images\ecnrypted_by_columns.bmp";
            var fileNameMatrixSample = @"C:\bstu_labs\labs-6-sem\ib\IB_Lab14\IB_Lab14\IB_Lab14\Images\matrix_sample.bmp";
            var fileNameMatrixEncryptByRows = @"C:\bstu_labs\labs-6-sem\ib\IB_Lab14\IB_Lab14\IB_Lab14\Images\matrix_encrypt_rows.bmp";
            var fileNameMatrixEncryptByColumns = @"C:\bstu_labs\labs-6-sem\ib\IB_Lab14\IB_Lab14\IB_Lab14\Images\matrix_encrypt_columns.bmp";
            var openTextByRows = "YashnyNikitaSergeevich";
            var openTextByColumns = "Text";
            Steganography.HideMessageByRows(fileNameOpen, openTextByRows, fileNameEncryptByRows);
            Steganography.HideMessageByColumns(fileNameOpen, openTextByColumns, fileNameEncryptByColumns);
            var resultByRows = Steganography.ExtractMessageByRows(fileNameEncryptByRows);
            var resultByColumns = Steganography.ExtractMessageByColumns(fileNameEncryptByColumns);
            Console.WriteLine($"Text by rows: {resultByRows}");
            Console.WriteLine($"Text by columns: {resultByColumns}");
            Steganography.GetColorMatrix(fileNameOpen, fileNameMatrixSample);
            Steganography.GetColorMatrix(fileNameEncryptByRows, fileNameMatrixEncryptByRows);
            Steganography.GetColorMatrix(fileNameEncryptByColumns, fileNameMatrixEncryptByColumns);
        }
    }
}