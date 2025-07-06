using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Model
{
    internal class ExpirableShippableProduct : Product, IExpirable, IShippable
    {
        private DateTime _expirationDate;
        private double _weight;

        public bool IsExpired => DateTime.Today > ExpirationDate;
        string IShippable.Name => Name;
        public DateTime ExpirationDate
        {
            get => _expirationDate;
            set
            {
                if (value == default)
                    Console.WriteLine("ExpirationDate must be a valid date.");
                else _expirationDate = value;
            }
        }

        public double Weight
        {
            get => _weight;
            set
            {
                if (value < 0.0)
                    Console.WriteLine(nameof(Weight), "Weight cannot be negative.");
                else _weight = value;
            }
        }

        public ExpirableShippableProduct(string name,decimal price,int quantity,DateTime expirationDate,double weight) : base(name, price, quantity)
        {
            ExpirationDate = expirationDate;
            Weight = weight;
        }

    }
}
