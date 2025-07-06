using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Model
{
    internal class Cart
    {
        public int id { get; set; }
        private List<Product> _products = new List<Product>();


        public List<Product> Products
        {
            get => _products;
            set
            {
                if (value == null)
                {
                    _products = new List<Product>();
                }
                else
                {
                    _products = value;
                }
            }
        }


        public void AddProduct(Product p)
        {
            if (p == null)
            {
                Console.WriteLine("Cannot add a null product to the cart.");
                return;
            }
            Products.Add(p);
        }

    }
}
