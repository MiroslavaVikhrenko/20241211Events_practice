using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace task12
{
    /*Создайте приложения для выполнения арифметических операций.Поддерживаемые операции: 
■ Проверка числа на чётность; 
■ Проверка числа на нечётность;
■ Проверка является ли число простым; 
■ Проверка является ли число числом Фибоначчи.
Обязательно используйте делегат типа «Predicate».*/

    //Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, …,
    //Prime: 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a number you want to check:");
                int n = Convert.ToInt32(Console.ReadLine());

                //check if a number is even or odd
                Predicate<int> p = (x) => x % 2 == 0;

                if (p.Invoke(n))
                {
                    Console.WriteLine($"{n} is even");
                }
                else
                {
                    Console.WriteLine($"{n} is odd");
                }

                //check if a number is prime

                p = (x) =>
                {
                    for (int i = 2; i < n; i++)
                    {
                        if (n % i == 0)
                            return false;
                    }
                    return true;
                };

                if (p.Invoke(n))
                {
                    Console.WriteLine($"{n} is prime");
                }
                else
                {
                    Console.WriteLine($"{n} is NOT prime");
                }

                //check if a number is Fibinacci

                Predicate<int> p2 = (x) =>
                {
                    int m = (int)Math.Sqrt(x);
                    return m * m == x;
                };

                p = (x) => p2.Invoke(5 * n * n + 4) || p2.Invoke(5 * n * n - 4);

                if (p.Invoke(n))
                {
                    Console.WriteLine($"{n} is Fibonacci");
                }
                else
                {
                    Console.WriteLine($"{n} is NOT Fibonacci");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
