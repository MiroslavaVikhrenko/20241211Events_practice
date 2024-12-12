using System.Globalization;

namespace task10
{
    internal class Program
    {
        /*Создайте набор методов: 
        ■ Метод для отображения текущего времени; 
        ■ Метод для отображения текущей даты; 
        ■ Метод для отображения текущего дня недели; 
        ■ Метод для подсчета площади треугольника; 
        ■ Метод для подсчета площади прямоугольника.
        Для реализации проекта используйте делегаты «Action», «Predicate», «Func»
        */
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            Action<DateTime> a = DisplayCurrentTime;
            a += DisplayCurrentDate;
            a += DisplayCurrentWeekDay;
            a.Invoke(dt);

            Predicate<DateTime> p = (dt) => dt.Hour >= 12;
            if (p.Invoke(dt))
            {
                Console.WriteLine("It's PM");
            }
            else
            {
                Console.WriteLine("It's AM");
            }

            Console.WriteLine("\n\n---------------------------------------\n\n");

            Func<double, double, double> f = CalculateSquareOfTriangle;
            Console.WriteLine($"Triangle S = {f.Invoke(5.0, 10.0)} cm2");

            Predicate<double> p1 = (s) => s > 10;

            if (p1.Invoke(f.Invoke(5.0, 10.0)))
            {
                Console.WriteLine("Square is bigger than 10");
            }
            else
            {
                Console.WriteLine("Square is less than or equal to 10");
            }

            Console.WriteLine("\n\n---------------------------------------\n\n");

            f = CalculateSquareOfRectangle;
            Console.WriteLine($"Rectangle S = {f.Invoke(2.0, 3.0)} cm2");
            if (p1.Invoke(f.Invoke(2.0, 3.0)))
            {
                Console.WriteLine("Square is bigger than 10");
            }
            else
            {
                Console.WriteLine("Square is less than or equal to 10");
            }

            Console.WriteLine("\n\n---------------------------------------\n\n");

            Console.ReadKey();
        }

        public static void DisplayCurrentTime(DateTime dt)
        {
            Console.WriteLine($"Current time: {dt.Hour} h {dt.Minute} min");
        }
        public static void DisplayCurrentDate(DateTime dt)
        {
            Console.WriteLine($"Current date: {dt.Year}, {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dt.Month)} {dt.Day}");
        }
        public static void DisplayCurrentWeekDay(DateTime dt)
        {
            Console.WriteLine($"Current week day: {dt.DayOfWeek}");
        }

        public static double CalculateSquareOfTriangle(double height, double side)
        {
            return (side * (height / 2));
        }

        public static double CalculateSquareOfRectangle(double sideA, double sideB)
        {
            return sideA * sideB;
        }

    }
}
