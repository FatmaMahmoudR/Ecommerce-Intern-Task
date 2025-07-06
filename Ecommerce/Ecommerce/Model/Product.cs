using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Model
{
    internal abstract class Product
    {
        private string _name;
        private decimal _price;
        private int _quantity;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    Console.Write("Name cannot be empty");
                else _name = value;
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0m)
                    Console.Write("Price cannot be negative");
                else _price = value;
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                    Console.Write("Quantity cannot be negative");
                else _quantity = value;
            }
        }

        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        //// Expiry (nullable)
        //public DateTime? ExpiryDate { get; set; }
        //public bool IsExpired => ExpiryDate.HasValue && DateTime.UtcNow > ExpiryDate.Value;

        //// Shipping (nullable)
        //public double? WeightInGrams { get; set; }
        //public bool RequiresShipping => WeightInGrams.HasValue && WeightInGrams.Value > 0;


    }
}
