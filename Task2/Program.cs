using System.Net;

namespace Task2
{
    internal class Program
    {
        //Создать класс «Полиция», со свойствами: id, name, age, address. 
        //Реализовать 3 метода для редактирования: name, age, address.
        //Создать массив объектов класса, редактировать информацию о некоторых из них.
        //При редактировании, повесить событие, для уведомления пользователя.

        static void Main(string[] args)
        {
            Police[] policemen = new Police[]
            {
                new Police("John", "Toronto", 35),
                new Police("Tom", "Edmonton", 24),
                new Police("Erik", "Calgary", 27),
                new Police("Levi", "Montreal", 40),
                new Police("Alex", "Vancouver", 39),
                new Police("Barry", "Regina", 30),
                new Police("Chris", "Red Deer", 50),
                new Police("Bob", "Halifax", 42)
            };

            PrintArray(policemen);

            policemen[0].Notify += DisplayMessage;
            policemen[0].UpdateName("Calvin");

            policemen[3].Notify += DisplayMessage;
            policemen[3].UpdateAddress("Ottawa");

            policemen[7].Notify += DisplayMessage;
            policemen[7].UpdateAge(40);

            PrintArray(policemen);

            Console.ReadKey();
        }
        static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        static void PrintArray(Police[] policemen)
        {
            Console.WriteLine("----------------Police staff list ----------------");
            for (int i = 0; i < policemen.Length; i++)
            {
                Console.WriteLine(policemen[i].ToString());
            }
            Console.WriteLine("--------------------------------------------------");
        }
    }

    public class Police
    {
        public delegate void PoliceHandler(string msg);
        public event PoliceHandler Notify;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Address: {Address}, Age: {Age}";
        }

        public Police(string name, string address, int age)
        {
            Id = Guid.NewGuid();
            Name = name;
            Address = address;
            Age = age;
        }

        public void UpdateName (string newName)
        {
            Name = newName;

            Notify?.Invoke($"User {Id} changed name to {Name}");
        }

        public void UpdateAddress (string newAddress)
        {
            Address = newAddress;
            Notify?.Invoke($"User {Id} changed address to {Address}");
        }

        public void UpdateAge (int newAge)
        {
            Age = newAge;

            Notify?.Invoke($"User {Id} changed age to {Age}");
        }
    }
}
