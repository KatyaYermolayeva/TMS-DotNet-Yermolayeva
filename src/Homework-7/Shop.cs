using System.Collections.Generic;

namespace Homework_7
{
    class Shop
    {
        public List<Cashier> Cashiers;
        public bool IsOpen;
        public Shop()
        {
            Name = "The Shop";
            Cashiers = new List<Cashier>();
        }

        public Shop(int cashiersCount)
        {
            Name = "The Shop";
            Cashiers = new List<Cashier>();
            for (int i = 0; i < cashiersCount; i++)
            {
                Cashiers.Add(new Cashier());
            }
        }

        public string Name { get; set; }
    }
}
