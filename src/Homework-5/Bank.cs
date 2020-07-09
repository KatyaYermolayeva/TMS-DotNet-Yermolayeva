using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework_5
{
    class Bank
    {
        public event Action<string> Notify;

        private readonly IList<Client> _clients = new List<Client>();

        private Dictionary<Tuple<MoneyType, MoneyType>, decimal> _exchangeRates
            = new Dictionary<Tuple<MoneyType, MoneyType>, decimal>()
        {
                { new Tuple<MoneyType, MoneyType>(MoneyType.BYN, MoneyType.EUR), 0.3637M },
                { new Tuple<MoneyType, MoneyType>(MoneyType.BYN, MoneyType.RUB), 29.3947M },
                { new Tuple<MoneyType, MoneyType>(MoneyType.BYN, MoneyType.USD), 0.4109M },
                { new Tuple<MoneyType, MoneyType>(MoneyType.EUR, MoneyType.BYN), 2.7493M },
                { new Tuple<MoneyType, MoneyType>(MoneyType.EUR, MoneyType.RUB), 80.8206M },
                { new Tuple<MoneyType, MoneyType>(MoneyType.EUR, MoneyType.USD), 1.1299M },
                { new Tuple<MoneyType, MoneyType>(MoneyType.RUB, MoneyType.USD), 0.014M },
                { new Tuple<MoneyType, MoneyType>(MoneyType.RUB, MoneyType.EUR), 0.0124M },
                { new Tuple<MoneyType, MoneyType>(MoneyType.RUB, MoneyType.BYN), 0.0341M },
                { new Tuple<MoneyType, MoneyType>(MoneyType.USD, MoneyType.RUB), 71.5269M},
                { new Tuple<MoneyType, MoneyType>(MoneyType.USD, MoneyType.EUR), 0.885M },
                { new Tuple<MoneyType, MoneyType>(MoneyType.USD, MoneyType.BYN), 2.4331M}

        };

        public bool Put(string accoundId, string clientId, decimal money)
        {
            Client client = _clients.SingleOrDefault(c => c.id == clientId);
            if (client != null)
            {
                client.UpdateBalance(accoundId, money);
                Notify?.Invoke($"На счет поступила сумма: {money:f2}{GetAccountById(accoundId).Item2.Type}");
                return true;
            }
            else
            {
                Notify?.Invoke("Клиент с данным id не найден в системе");
                return false;
            }
        }

        public bool Take(string accoundId, string clientId, decimal money)
        {
            Client client = _clients.SingleOrDefault(c => c.id == clientId);
            if (client != null)
            {
                decimal clientBalance = client.GetBalance(accoundId);
                if (clientBalance > money)
                {
                    client.UpdateBalance(accoundId, -money);
                    Notify?.Invoke($"Со счета была снята сумма: {money:f2}{GetAccountById(accoundId).Item2.Type}");
                    return true;
                }
                else
                {
                    Notify?.Invoke("На счету не хватает денеженых средств");
                }
            }
            else
            {
                Notify?.Invoke("Клиент с данным id не найден в системе");
            }
            return false;
        }
        public void AddNewClient(Client client)
        {
            _clients.Add(client);
        }

        public void GetClientInfo(string id)
        {
            Client client = _clients.SingleOrDefault(c => c.id == id);
            if (client != null)
            {
                client.GetInfo();
            }
            else
            {
                Notify?.Invoke("Клиент с данным id не найден в системе");
            }
        }

        public void AddNewclientAccount(string id, MoneyType type)
        {
            Client client = _clients.SingleOrDefault(c => c.id == id);
            if (client != null)
            {
                client.AddAccount(new Account(type));
            }
            else
            {
                Notify?.Invoke("Клиент с данным id не найден в системе");
            }
        }

        public void ExchangeMoney(string acc1Id, string acc2Id, decimal money)
        {
            var acc1 = GetAccountById(acc1Id);
            var acc2 = GetAccountById(acc2Id);
            if (acc1 == null || acc2 == null)
            {
                Notify?.Invoke("Счет с данным id не найден в системе.");
                return;
            }
            if (acc1Id == acc2Id)
            {
                Notify?.Invoke("Ошибка - попытка перевода на тот же счет.");
                return;
            }
            decimal rate = 1;
            if (acc1.Item2.Type != acc2.Item2.Type)
            {
                _exchangeRates.TryGetValue(new Tuple<MoneyType, MoneyType>(acc1.Item2.Type, acc2.Item2.Type),
                    out rate);
            }
            if (Take(acc1.Item2.Id, acc1.Item1.id, money))
            {
                Put(acc2.Item2.Id, acc2.Item1.id, money * rate);
            }
        }
        private Tuple<Client, Account> GetAccountById(string id)
        {
            foreach (var client in _clients)
            {
                foreach (var account in client.accounts)
                {
                    if (account.Id == id)
                    {
                        return new Tuple<Client, Account>(client, account);
                    }
                }
            }
            return null;
        }
    }
}
