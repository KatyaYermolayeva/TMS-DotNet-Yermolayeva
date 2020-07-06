using System;

namespace Homework_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank();
            bank.Notify += ShowMessage;

            var client1 = new Client("Ivanov Ivan Ivanovich");
            var account1 = new Account(MoneyType.BYN)
            {
                Id = Guid.NewGuid().ToString(),
                Balance = 100.25M
            };
            var account2 = new Account(MoneyType.USD)
            {
                Id = Guid.NewGuid().ToString(),
                Balance = 0.15M
            };
            client1.accounts.Add(account1);
            client1.accounts.Add(account2);
            bank.AddNewClient(client1);

            var client2 = new Client("Petrov Petr Petrovich");
            var account3 = new Account(MoneyType.EUR)
            {
                Id = Guid.NewGuid().ToString(),
                Balance = 300.00M
            };
            var account4 = new Account(MoneyType.USD)
            {
                Id = Guid.NewGuid().ToString(),
                Balance = 700.40M
            };
            client2.accounts.Add(account3);
            client2.accounts.Add(account4);
            bank.AddNewClient(client2);

            var client3 = new Client("Smirnov Miron Mironovich");
            var account5 = new Account(MoneyType.RUB)
            {
                Id = Guid.NewGuid().ToString(),
                Balance = 50.25M
            };
            var account6 = new Account(MoneyType.BYN)
            {
                Id = Guid.NewGuid().ToString(),
                Balance = 3090.12M
            };
            var account7 = new Account(MoneyType.BYN)
            {
                Id = Guid.NewGuid().ToString(),
                Balance = 300.1M
            };
            client3.accounts.Add(account5);
            client3.accounts.Add(account6);
            client3.accounts.Add(account7);
            bank.AddNewClient(client3);

            client1.GetInfo();
            Console.WriteLine();
            client2.GetInfo();
            Console.WriteLine();
            client3.GetInfo();
            Console.WriteLine();
            bank.ExchangeMoney(account2.Id, account6.Id, 20);
            bank.Put(account2.Id, client1.id, 100);
            bank.Take(account3.Id, client2.id, 14.6M);
            bank.ExchangeMoney(account3.Id, account3.Id, 450);
            bank.ExchangeMoney(account5.Id, account6.Id, 42);
            bank.ExchangeMoney(account1.Id, account4.Id, 89.49M);
            Console.WriteLine();
            client1.GetInfo();
            Console.WriteLine();
            Console.WriteLine();
            client2.GetInfo();
            Console.WriteLine();
            client3.GetInfo();

            Console.ReadKey();
        }

        private static void ShowMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
