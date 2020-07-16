using System;
using System.Collections.Generic;

namespace Homework_7
{
    class Customer
    {
        private static int _globalId = 0;
        private readonly int _id;
        public int ShoppingSpeed { get; set; }
        public IList<Product> Basket { get; set; } = new List<Product>();

        public Customer()
        {
            _id = ++_globalId;
            FillBasket();
            Name = $"Customer {_id}";
            var rand = new Random();
            ShoppingSpeed = rand.Next(100, 1000);
        }

        public Customer(int basketSize)
        {
            _id = ++_globalId;
            Name = $"Customer {_id}";
            FillBasket(basketSize);
            var rand = new Random();
            ShoppingSpeed = rand.Next(100, 1000);
        }

        public Customer(int basketSize, int shoppingSpeed)
        {
            _id = ++_globalId;
            Name = $"Customer {_id}";
            FillBasket(basketSize);
            ShoppingSpeed = shoppingSpeed;
        }
        public void FillBasket()
        {
            var random = new Random();
            int productsCount = random.Next(1, 15);
            for (int i = 0; i < productsCount; i++)
            {
                Basket.Add(new Product());
            }
        }

        public void FillBasket(int productsCount)
        {
            if (productsCount < 1)
            {
                throw new ArgumentException("Invalid argument - productsCount < 1.");
            }
            for (int i = 0; i < productsCount; i++)
            {
                Basket.Add(new Product());
            }
        }

        public string Name { get; set; }
        public int BasketSize
        {
            get
            {
                return Basket.Count;
            }
        }
    }
}
