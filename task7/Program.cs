namespace task7
{
    internal class Program
    {
        //Используя делегат «Func» и лямбда выражение, посчитать сумму 4-ех элементов.
        static void Main(string[] args)
        {
            Func<int, int, int, int, int> f = (a, b, c, d) => a + b + c + d;
            int result = f.Invoke(1, 2, 3, 4);
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
