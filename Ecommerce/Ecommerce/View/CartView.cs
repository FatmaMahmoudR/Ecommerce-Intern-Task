using Ecommerce.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.View
{
    internal class CartView : ICartView
    {
        public void DisplayResult(bool ok, string msg)
        {
            Console.WriteLine(msg);
        }

        public void DisplayReceipt(bool ok, string msg, double sub, double fee, double total)
        {
            Console.WriteLine("-- Receipt --");
            Console.WriteLine($"Subtotal: {sub:C}");
            Console.WriteLine($"Shipping: {fee:C}");
            Console.WriteLine($"Total:    {total:C}");
            Console.WriteLine(msg);
        }

        
    }
}
