using System;
using System.Collections.Generic;

namespace Homework_7
{
    class Cashier
    {
        public readonly Queue<Customer> CustomersInLine;
        public bool isFree { get; set; }

        public int Speed { get; set; }

        public Cashier()
        {
            CustomersInLine = new Queue<Customer>();
            isFree = true;
            var rand = new Random();
            Speed = rand.Next(100, 1000);
        }

        public Cashier(int speed)
        {
            CustomersInLine = new Queue<Customer>();
            isFree = true;
            Speed = speed;
        }

        public int LineSize
        {
            get
            {
                return CustomersInLine.Count;
            }
        }

        public void AddCustomer(Customer customer)
        {
            CustomersInLine.Enqueue(customer);
        }

        public void CheckoutCustomer()
        {
            CustomersInLine.Dequeue();
        }
    }
}
