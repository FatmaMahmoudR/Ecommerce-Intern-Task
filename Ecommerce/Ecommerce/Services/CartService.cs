﻿using Ecommerce.Model;
using Ecommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    internal class CartService : ICartService
    {
        private readonly IProductService _productService;
        private readonly IShippingService _shippingService;
        private readonly Cart _cart = new();

        public CartService(IProductService p, IShippingService s)
        {
            _productService = p;
            _shippingService = s;
        }

        public (bool, string) AddToCart(string name, int qty)
        {
            var product = _productService.ShowAll().FirstOrDefault(p => p.Name == name);

            if (product == null) return (false, "[X] Product not found");

            if (qty <= 0) return (false, "[X] Quantity must be positive");

            if (product is IExpirable exp && exp.IsExpired)
                return (false, $"[X] {product.Name} has expired");

            if (product.Quantity ==0 ) return (false, $"[X] {product.Name} out of stock");

            if (product.Quantity < qty) return (false, $"[X] only {product.Quantity} in the stock");

            product.Quantity -= qty;

            for (int i = 0; i < qty; i++)
                _cart.AddProduct(product);

            return (true, $"Added {qty}× {name}");
        }


        public (bool, string, double, double, double, IEnumerable<Product>) Checkout(Customer customer)
        {
            if (!_cart.Products.Any())
                return (false, "[X] Cart is empty", 0, 0, 0, Enumerable.Empty<Product>());

            var items = _cart.Products.ToList();
            var sub    = _cart.Products.Sum(p => p.Price);

            var weight = _cart.Products.OfType<IShippable>().Sum(p => p.Weight);

            var fee    = _shippingService.ShippingFee(weight);

            var total  = sub + fee;

            if (total > customer.Balance)
                return (false, $"[X] low balance: {customer.Balance}$", sub, fee, total, items);

            customer.Balance -= total;
            _cart.Products.Clear();

            return (true, "Checkout successful", sub, fee, total,items);
        }


        public IEnumerable<Product> GetAllProducts()
        {
            
            return _cart.Products;
        }


    }
}
