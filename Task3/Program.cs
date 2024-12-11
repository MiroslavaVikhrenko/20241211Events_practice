namespace Task3
{
    internal class Program
    {
        //Создать приложение, в котором генератор события после генерации первого события генерирует
        //только определенное количество событий.
        //Количество генераций определяется путем уведомления со стороны клиента.
        //Для уведомления использовать второй параметр обработчика события. Консольный вывод примерный: 

        //Создали - 1 событие(й). 
        //Сколько еще событий сгенерировать?: 2 
        //Создали - 2 событие(й). 
        //Создали - 3 событие(й).
        static void Main(string[] args)
        {
            EventGenerator e1 = new EventGenerator();


            e1.Notify += DisplayMessage;
            e1.Message(1);

            try
            {
                Console.WriteLine("How many more events do you want to generate?");
                int count = Convert.ToInt32(Console.ReadLine());

                for (int i = 2; i <= count + 1; i++)
                {
                    e1.Message(i);
                }
            }
            catch (Exception ex)
            {

            }

            Console.ReadKey();
        }


        static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

    }

    public class EventGenerator
    {
        public delegate void Del(string msg);
        public event Del Notify;

        public void Message(int number)
        {
            if (number == 1)
            {
                Notify?.Invoke($"Created - {number} Event");
            }
            else
            {
                Notify?.Invoke($"Created - {number} Events");
            }
        }
    }
}
