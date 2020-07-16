using System;

namespace Homework_7
{
    class Product
    {
        public string Code { get; set; } = Guid.NewGuid().ToString();
        public Decimal Price { get; set; }

        public Product()
        {
            var random = new Random();
            Price = random.Next(10, 1000);
        }

        public override string ToString()
        {
            return Code;
        }
    }
}
