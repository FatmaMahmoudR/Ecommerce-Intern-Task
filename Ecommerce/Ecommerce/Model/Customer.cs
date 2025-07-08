using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Model
{
    internal class Customer
    {
        public int Id { get; set; }

        private string _name;
        private double _balance;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    Console.WriteLine("name cannot be empty.");
                else
                    _name = value;
            }
        }

        public double Balance
        {
            get => _balance;
            set
            {
                if (value < 0)
                    Console.WriteLine("balance cannot be negative");
                else
                    _balance = value;
            }
        }
    }
}
