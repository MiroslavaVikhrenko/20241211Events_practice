namespace task9
{
    internal class Program
    {
        //Создать класс «Person». Создать массив класса на 4 элемента. Используя делегат «Predicate», найти пользователя с Id == 1.
        static void Main(string[] args)
        {
            Customer[] customers = new Customer[2];
            customers[0] = new Customer() { Id = 1, Name = "Alex", Age = 25 };
            customers[1] = new Customer() { Id = 2, Name = "Tom", Age = 21 };
            Predicate<Customer> hydCustomers = x => x.Id == 1;
            foreach (var item in customers)
            {
                if (hydCustomers.Invoke(item))
                {
                    Console.WriteLine($"Id - {item.Id}, Name - {item.Name}, Age - {item.Age}.");
                }
            }
            Console.ReadKey();
        }

    }
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
