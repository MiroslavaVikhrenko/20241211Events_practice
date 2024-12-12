namespace task5_20241212
{
    internal class Program
    {
        //Используя делегат «Predicate», принимать строку и проверять ее на длину. Если меньше 7 символов – вернуть false, иначе true.
        //Для проверки строки, использовать метод.
        static void Main(string[] args)
        {
            Predicate<string> IsBigString = CheckString;

            if (IsBigString.Invoke("gjhjhjgjhhjgj"))
            {
                Console.WriteLine("more than 7");
            }
            else
            {
                Console.WriteLine("less than 7");
            }
            Console.ReadKey();
        }

        static bool CheckString(string str)
        {
            if (str.Length < 7)
            {
                return false;
            }
            return true;
        }
    }
}
