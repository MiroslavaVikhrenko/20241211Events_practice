using System.Net.NetworkInformation;

namespace Task4
{
    internal class Program
    {
//Создайте класс «Кредитная карточка». Класс должен содержать: 

//■ Номер карты;
//■ ФИО владельца; 
//■ Срок действия карты; 
//■ PIN; 
//■ Кредитный лимит; 
//■ Сумма денег.

//Создайте необходимый набор методов класса. Реализуйте события для следующих ситуаций: 

//■ Пополнение счёта; 
//■ Расход денег со счёта; 
//■ Старт использования кредитных денег; 
//■ Достижение заданной суммы денег; 
//■ Смена PIN.
        static void Main(string[] args)
        {
            CreditCard cc = new CreditCard("Yuko Satou", new DateTime(2029, 5, 30), 3333, 1500.0m, 5000.0m);
            PrintInfo(cc);

            cc.Notify += DisplayMessage;
            cc.ChangePin(4444);
            PrintInfo(cc);

            cc.UseCredit(2000.0m);
            cc.UseCredit(1000.0m);
            cc.AddSum(1000.0m);
            PrintInfo(cc);

            cc.SpendMoney(5000.0m);
            PrintInfo(cc);

            cc.SpendMoney(2000.0m);
            PrintInfo(cc);

            Console.ReadKey();
        }

        public static void PrintInfo(CreditCard cc)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(cc.ToString());
            Console.ResetColor();
            Console.WriteLine("---------------------------------------------------");
        }
        static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class CreditCard
    {
        public delegate void CreditCardHandler(string msg);
        public event CreditCardHandler Notify;
        public Guid Number { get; set; }
        public string FullName { get; set; }
        public DateTime Expiration { get; set; }
        public int Pin {  get; set; }
        public decimal CreditLimit { get; set; }
        public decimal Balance { get; set; }

        public override string ToString()
        {
            return $"Number: {Number}, Pin: {Pin}\n{FullName}, Expiration date: {Expiration}\nCredit limit: {CreditLimit} CAD, Balance: {Balance} CAD";
        }

        public CreditCard(string fullName, DateTime expiration, int pin, decimal creditLimit, decimal balance)
        {
            Number = Guid.NewGuid();
            FullName = fullName;
            Expiration = expiration;
            Pin = pin;
            CreditLimit = creditLimit;
            Balance = balance;
        }

        public void AddSum(decimal sum)
        {
            Balance += sum;
            Notify?.Invoke($"{sum} CAD was added to your balance. Current balance is {Balance} CAD");
        }

        public void SpendMoney(decimal sum)
        {
            if (Balance >= sum)
            {
                Balance -= sum;
                Notify?.Invoke($"{sum} CAD was spent. Current balance is {Balance} CAD");
            }
            else
            {
                Notify?.Invoke($"OPERATION DENIED!!! Attempted to spend {sum} CAD. But current balance is {Balance} CAD which is below the requested sum.");
            }
        }

        public void UseCredit(decimal credit)
        {
            if (credit <= CreditLimit)
            {
                CreditLimit -= credit;
                Notify?.Invoke($"{credit} CAD credit was used. Current credit limit is {CreditLimit} CAD");
            }
            else
            {
                Notify?.Invoke($"OPERATION DENIED!!! Attempted to use {credit} CAD credit. But current credit limit is {CreditLimit} CAD which is below the requested sum");
            }
        }

        public void ChangePin(int newPin)
        {
            Pin = newPin;
            Notify?.Invoke($"Pin has been successfully changed to {Pin}");
        }
    }
}
