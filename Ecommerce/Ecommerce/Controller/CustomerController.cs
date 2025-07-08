using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Controller
{
    internal class CustomerController
    {
        public CustomerController() { }

        public void details(Customer customer)
        {
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }
            Console.WriteLine($"Customer ID: {customer.Id} | Name: {customer.Name} | Balance: {customer.Balance} ");            
            
        }
    }
}
