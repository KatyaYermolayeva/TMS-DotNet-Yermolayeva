using System;
using System.Threading;

namespace Homework_7
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopManager shopManager;
            var rand = new Random();

            Console.Write("Enter number of customers (>0): ");
            Int32.TryParse(Console.ReadLine(), out int customersCount);
            if (customersCount == 0)
            {
                customersCount = rand.Next(1, 1000);
            }
            Console.Write("Enter number of cashiers (>0): ");
            Int32.TryParse(Console.ReadLine(), out int cashiersCount);
            if (cashiersCount != 0)
            {
                shopManager = new ShopManager(new Shop(cashiersCount));
            }
            else
            {
                shopManager = new ShopManager(new Shop());
            }
            for (int i = 0; i < customersCount; i++)
            {
                shopManager.AddCustomer(new Customer());
                Thread.Sleep(rand.Next(100, 1000));
            }
        }
    }
}
