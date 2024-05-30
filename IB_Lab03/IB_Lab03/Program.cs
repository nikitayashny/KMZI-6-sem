using IB_Lab03;

internal class Program
{
    private static void Main(string[] args)
    {
        const ulong m = 632;
        const ulong n = 663;
        Console.WriteLine($"\nНОД ({m}, {n}) = {Modular.GetGCD(m, n)}");
        Console.WriteLine($"НОД (4, 8, 32) = {Modular.GetGCD(4, Modular.GetGCD(32, 8))}");
        Console.WriteLine($"\nПростые числа от 2 до {n} ({Modular.GetPrimesCount(n)} чисел):");
        foreach (var item in Modular.GetPrimes(n))
            Console.Write($"{item} ");
        Console.WriteLine($"\n\nПростые числа от {m} до {n} ({Modular.GetPrimesCount(m, n)} чисел):");
        foreach (var item in Modular.GetPrimes(m, n))
            Console.Write($"{item} ");
        Console.WriteLine($"\n\n{n} / ln({n}) = {Modular.GetApproximatePrimesCount(n)}");
        for (ulong i = m; i <= n; i++)
            Console.WriteLine($"Число {i} в канонической форме: {Modular.GetCanonicalForm(i)}");
        Console.WriteLine($"\nЯвляется ли число {m}{n} простым?\n{Modular.IsPrimeByNumbersConcat(m, n)}");
    }
}