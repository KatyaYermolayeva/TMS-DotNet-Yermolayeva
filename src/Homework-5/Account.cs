using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_5
{
    class Account
    {
        public string Id { get; set; }
        public MoneyType Type { get; }
        public decimal Balance { get; set; }

        public Account(MoneyType type)
        {
            Id = Guid.NewGuid().ToString();
            Balance = 0;
            Type = type;
        }
    }
}
