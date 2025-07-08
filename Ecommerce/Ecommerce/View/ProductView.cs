using Ecommerce.Model;
using Ecommerce.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.View
{
    internal class ProductView :IProductView
    {
        public void DisplayAll(IEnumerable<Product> products)
        {
            Console.WriteLine("All Products:");
            int i = 1;
            foreach (var p in products)
                Console.WriteLine($"{i++}: {p.Name}| Price={p.Price}, Stock={p.Quantity}");
        }
    }
}
