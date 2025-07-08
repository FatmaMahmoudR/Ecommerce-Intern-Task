using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Model
{
    internal class ExpirableProduct : Product, IExpirable
    {
        private DateTime _expirationDate;

        public DateTime ExpirationDate
        {
            get => _expirationDate;
            set
            {
                if (value == default)
                    Console.WriteLine("ExpirationDate must be a valid date");
                else _expirationDate = value;
            }
        }

        public bool IsExpired => DateTime.Today > ExpirationDate;

        public ExpirableProduct(string name,double price,int quantity,DateTime expirationDate) : base(name, price, quantity)
        {
            ExpirationDate = expirationDate;
        }
    }
}
