namespace task6
{
    internal class Program
    {
        //Используя делегат  «Predicate», принимать строку и проверять ее на длину.
        //Если меньше 7 символов – вернуть false, иначе true. Для проверки строки, использовать лямбда выражение.
        static void Main(string[] args)
        {
            Predicate<string> IsBigString = (str) => str.Length >= 7;
            Console.WriteLine(IsBigString.Invoke("gjhjhjgjhhjgj"));


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
