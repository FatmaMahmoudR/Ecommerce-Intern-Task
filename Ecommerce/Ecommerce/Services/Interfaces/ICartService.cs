using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interfaces
{
    internal interface ICartService
    {
        (bool ok, string msg) AddToCart(string productName, int quantity);


        (bool ok, string msg, double subtotal, double shippingFee, double total) Checkout(Customer customer);


        IEnumerable<Product> GetAllProducts();

    }
}
