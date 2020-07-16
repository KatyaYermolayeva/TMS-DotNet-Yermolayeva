using System;
using System.Linq;
using System.Threading;

namespace Homework_7
{
    class ShopManager
    {
        private readonly Shop _shop;
        private static Object locker = new Object();

        public ShopManager()
        {
            _shop = new Shop();
        }

        public ShopManager(Shop shop)
        {
            _shop = shop;
        }

        public void AddCustomer(Customer customer)
        {
            Thread thread = new Thread(DoShopping);
            thread.Start(customer);
        }

        public void AddCashier()
        {
            _shop.Cashiers.Add(new Cashier());
        }

        public void DoShopping(Object c)
        {
            if (!(c is Customer))
            {
                throw new ArgumentException();
            }
            var customer = (Customer)c;
            lock (locker)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{customer.Name} entered {_shop.Name} at {DateTime.Now.TimeOfDay}.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Thread.Sleep(customer.ShoppingSpeed * customer.BasketSize);
            var cashier = _shop.Cashiers.Aggregate((a, b) => a.LineSize < b.LineSize ? a : b);
            cashier.AddCustomer(customer);
            lock (locker)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{customer.Name} stood in line " +
                    $"at cashier {_shop.Cashiers.IndexOf(cashier) + 1} at {DateTime.Now.TimeOfDay}, " +
                    $"products in the basket - {customer.BasketSize}.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            while (!cashier.isFree && cashier.CustomersInLine.Peek() != customer) ;
            cashier.isFree = false;
            lock (locker)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{customer.Name} is checking out" +
                    $" at cashier {_shop.Cashiers.IndexOf(cashier) + 1} at {DateTime.Now.TimeOfDay}.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Thread.Sleep(cashier.Speed * customer.BasketSize);
            lock (locker)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{customer.Name} checked out " +
                    $"at cashier {_shop.Cashiers.IndexOf(cashier) + 1} at {DateTime.Now.TimeOfDay}.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            cashier.CheckoutCustomer();
            cashier.isFree = true;
        }

        public void OpenShop()
        {
            _shop.IsOpen = true;
        }

        public void CloseShop()
        {
            _shop.IsOpen = false;
        }
    }
}
