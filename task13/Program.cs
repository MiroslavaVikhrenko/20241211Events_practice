namespace task13
{
    internal class Program
    {
        /*
         Вы создаете приложение для электронной коммерции, которое позволяет пользователям фильтровать продукты 
        на основе их ценового диапазона. Вы хотите реализовать функцию, которая принимает в качестве 
        параметров список продуктов и делегат функции. Делегат функции должен принимать в качестве 
        параметра продукт и возвращать булево значение, указывающее, находится ли цена продукта в 
        указанном ценовом диапазоне. Реализация должна возвращать новый список продуктов, 
        отфильтрованных в соответствии с заданными критериями.
         */
        static void Main(string[] args)
        {
            Product[] products =
            {
                new Product("tomato", 3.0m),
                new Product("cucumber", 2.0m),
                new Product("eggs", 10.0m),
                new Product("beef", 18.0m),
                new Product("chicken", 13.0m),
                new Product("cookies", 9.0m),
                new Product("ginger", 1.5m),
                new Product("rice", 3.0m),
                new Product("pasta", 2.5m)
            };

            Console.WriteLine("---------------------Original list of products---------------------\n\n");
            PrintArray(products);

            Console.WriteLine("-------------------------------------------------------------------\n\n");

            try
            {
                Console.WriteLine("Enter you price limit:");
                decimal limit = Convert.ToDecimal(Console.ReadLine());

                Predicate<Product> p = (x) => x.Price <= limit;

                PrintArray(FindAllMatchingProducts(products, p));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static Product[] FindAllMatchingProducts(Product[] products, Predicate<Product> p)
        {
            int count = 0;
            for (int i = 0; i < products.Length; i++)
            {
                if (p(products[i]))
                {
                    count++;
                }
            }

            Product[] matchingProducts = new Product[count];

            int count2 = 0;

            for (int i = 0; i < products.Length; i++)
            {
                if (p(products[i]))
                {
                    matchingProducts[count2] = products[i];
                    count2++;
                }
            }
            return matchingProducts;

        }
        public static void PrintArray(Product[] products)
        {
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"{i+1}. {products[i].ToString()}");
            }
        }

    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} : {Price} CAD";
        }
    }
}
