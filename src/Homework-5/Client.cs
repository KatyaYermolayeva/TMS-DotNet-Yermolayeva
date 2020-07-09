using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework_5
{
    class Client
    {
        public readonly string id; // asdasd-d12312das-dasda
        private string _fullName;

        public readonly List<Account> accounts = new List<Account>();

        public Client(string fullName)
        {
            id = Guid.NewGuid().ToString();
            _fullName = fullName;
        }

        public void SetFullName(string fullName)
        {
            if (!string.IsNullOrEmpty(fullName))
            {
                _fullName = fullName;
            }
            else
            {
                Console.WriteLine("Не могу сменить имя");
            }
        }

        public void UpdateBalance(string id, decimal money)
        {
            Account account = accounts.SingleOrDefault(a => a.Id == id);
            account.Balance += money;
        }

        public decimal GetBalance(string id)
        {
            Account account = accounts.SingleOrDefault(a => a.Id == id);
            return account.Balance;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Full name: {_fullName}");

            foreach (var account in accounts)
            {
                Console.WriteLine($"Account: {account.Id}, Balance: {account.Balance:f2}{account.Type}");
            }
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

    }
}
