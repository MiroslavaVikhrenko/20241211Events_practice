namespace task11
{
    internal class Program
    {
        /*
         Реализуйте функцию, принимающую в качестве параметров список целых чисел и делегат функции.
        Делегат функции должен принимать целое число и возвращать булево значение.
        Реализация должна вернуть новый список, содержащий только те целые числа, 
        которые удовлетворяют условию, заданному делегатом функции «Func<int, bool>». 
        */
        static void Main(string[] args)
        {
            int[] originalArray = { 10, 15, 0, -10, -18, 0, 70, -100, 1, -4, -3, -17, 0, 80 };
            PrintArray(originalArray);

            Predicate<int> p = (x) => x > 0;

            int[] newArray = GetNewArray(originalArray, p);
            PrintArray(newArray);

            Console.ReadKey();
        }

        public static void PrintArray(int[] array)
        {
            Console.WriteLine("\n\n-------------Array-------------\n\n");

            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    Console.Write($" {array[i]}");
                }
                else
                {
                    Console.Write($" {array[i]} |");
                }
            }

        }

        public static int[] GetNewArray(int[] array, Predicate<int> p)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (p.Invoke(array[i]))
                {
                    count++;
                }
            }

            int[] newArray = new int[count];

            int count2 = 0;
            for (int i = 0;i < array.Length; i++)
            {
                if (p.Invoke(array[i]))
                {
                    newArray[count2] = array[i];
                    count2++;
                }
            }
            return newArray;
        }

    }
}
