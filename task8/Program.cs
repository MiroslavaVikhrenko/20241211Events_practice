namespace task8
{
    internal class Program
    {
        //Используя делегат «Action» и лямбда выражение, выполнить сортировку передаваемого туда массива.
        static void Main(string[] args)
        {
            int[] array1 = { 3, 5, 1, 7, 0 };
            Action<int[]> a = (array) => Array.Sort(array);

            a.Invoke(array1);

            for (int i = 0; i < array1.Length; i++)
            {
                Console.WriteLine(array1[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
