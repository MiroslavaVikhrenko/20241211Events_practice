namespace _20241211Events_practice
{
    internal class Program
    {
        //Создайте класс «Пользователь» с полем: имя. Создать методы: гулять, кушать, спать.
        //Каждый раз при вызове методов, с помощью события уведомлять о происходящем действии. 
        static void Main(string[] args)
        {
            User u1 = new User("Midori");
            User u2 = new User("Takeshi");
            User u3 = new User("Ken");

            User[] users = {u1, u2, u3};

            for (int i = 0; i < users.Length; i++)
            {
                users[i].Notify += DisplayMessage;
                users[i].Sleep();
                users[i].Eat();
                users[i].Walk();
            }

            Console.ReadKey();
        }

        static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class User
    {
        public delegate void UserHandler(string msg);
        public event UserHandler Notify;

        public string Name { get; set; }

        public User(string name)
        {
            Name = name;
        }

        public void Walk()
        {
            Notify?.Invoke($"{Name} is walking now");
        }

        public void Eat()
        {
            Notify?.Invoke($"{Name} is eating now");
        }

        public void Sleep()
        {
            Notify?.Invoke($"{Name} is sleeping now");
        }
    }
}
