using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Controller
{
    internal class ProductController
    {
        private readonly List<Product> _stock;

        public ProductController(List<Product> stock)
        {
            _stock = stock;
        }

        public void ShowAll()
        {
            Console.WriteLine("Available Products:");
            if (_stock.Count == 0)
            {
                Console.WriteLine("No products available");
                return;
            }
            int i = 1;
            foreach (var product in _stock)
            {
                Console.WriteLine($"{i++}: {product.Name}| Price={product.Price}| Stock={product.Quantity}");
            }
            Console.WriteLine();
        }
    }
}
