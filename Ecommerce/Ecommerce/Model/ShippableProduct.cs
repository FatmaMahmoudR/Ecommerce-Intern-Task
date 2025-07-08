using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Model
{
    internal class ShippableProduct : Product, IShippable
    {
        private double _weight;

        public double Weight
        {
            get => _weight;
            set
            {
                if (value < 0.0)
                    Console.WriteLine("Weight cannot be negative or zero");
                else _weight = value;
            }
        }
        string IShippable.Name => Name;

        public ShippableProduct(string name,double price,int quantity,double weight) : base(name, price, quantity)
        {
            Weight = weight;
        }

    }
}
