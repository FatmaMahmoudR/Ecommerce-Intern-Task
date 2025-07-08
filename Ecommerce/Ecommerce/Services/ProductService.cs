using Ecommerce.Model;
using Ecommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    internal class ProductService : IProductService
    {

        private readonly List<Product> _productList = new()
        { 
            new ExpirableShippableProduct("Cheese", 100, 5,DateTime.Today.AddDays(7), 0.2),
            new ExpirableShippableProduct("Biscuits",150,3, DateTime.Today.AddDays(10),0.7),
            new ShippableProduct("TV",  500,20,2.5),
            new Product("Scratch Card", 50, 10)
        };

        public IEnumerable<Product> ShowAll() => _productList;
    }

}
