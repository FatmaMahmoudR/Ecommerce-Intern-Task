using Ecommerce.Model;
using Ecommerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Controller
{
    internal class CartController
    {
        private List<Product> _stock;
        private ShippingService _shipping;

        public CartController(List<Product> inventory, ShippingService shippingService)
        {
            _stock = inventory;
            _shipping = shippingService;
        }

        /// <summary>
        /// Displays all available products in the stock
        /// if the stock is empty, it will display a message
        /// if a product isexpirable, it will display the expiration date and
        /// if is shippable, it will display the weight
        /// </summary>
        public void ShowProducts()
        {
            Console.WriteLine("Available Products:");

            if (_stock.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }
            foreach (var p in _stock)
            {
                
                Console.WriteLine($"- {p.Name}: Price={p.Price}, Stock={p.Quantity}" +
                    (p is IExpirable e ? $", Expires={e.ExpirationDate:d}" : "") +
                    (p is IShippable s ? $", Weight={s.Weight}kg" : ""));
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        
        public void AddToCart(Cart cart, string productName, int qty)
        {
            var prod = _stock.FirstOrDefault(p => p.Name == productName);
            if (prod == null)
            {
                Console.WriteLine($"[X] Product '{productName}' not found");
                return;
            }
            if (qty <= 0)
            {
                Console.WriteLine("[X] Quantity must be at least 1");
                return;
            }
            if (prod.Quantity < qty)
            {
                Console.WriteLine($"[X] Only {prod.Quantity} '{prod.Name}' in stock");
                return;
            }
            if (prod is IExpirable exp && exp.IsExpired)
            {
                Console.WriteLine($"[X] '{prod.Name}' is expired");
                return;
            }

            prod.Quantity -= qty;

            for (int i = 0; i < qty; i++)
                cart.Products.Add(prod);
        }


        public void Checkout(Customer customer, Cart cart)
        {
            if (!cart.Products.Any())
            {
                Console.WriteLine("[X] Cart is empty");
                return;
            }
            if (cart.Products.OfType<IExpirable>().Any(e => e.IsExpired))
            {
                Console.WriteLine("[X] Cart contains expired items");
                return;
            }

            // Receipt items
            var receipt = cart.Products
                .GroupBy(p => p.Name)
                .Select(g => (Name: g.Key, Qty: g.Count(), Total: g.First().Price * g.Count()))
                .ToList();

            decimal subtotal = receipt.Sum(x => x.Total);

            // Shippable items
            var shipped = cart.Products
                .OfType<IShippable>()
                .GroupBy(p => p.Name)
                .Select(g => (g.Key, Qty: g.Count(), Weight: ((IShippable)g.First()).Weight))
                .ToList();

            double totalWeight = shipped.Sum(x => x.Weight * x.Qty);
            decimal fee = _shipping.ShippingFee(totalWeight);
            decimal total = subtotal + fee;

            if (total > customer.Balance)
            {
                Console.WriteLine("[X] Not enough balance");
                return;
            }

            customer.Balance -= total;

            if (shipped.Any())
            {
                Console.WriteLine("** Shipment notice **");
                double wsum = 0;
                foreach (var (n, q, w) in shipped)
                {
                    double wgt = w * q;
                    wsum += wgt;
                    Console.WriteLine($"{q}x {n} {wgt:0.###}kg");
                }
                Console.WriteLine($"Total package weight {wsum:0.###}kg\n");
            }

            Console.WriteLine("** Checkout receipt **");

            foreach (var (n, q, t) in receipt)
                Console.WriteLine($"{q}x {n} {t:0.##}");

            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal {subtotal:0.##}");
            Console.WriteLine($"Shipping {fee:0.##}");
            Console.WriteLine($"Amount {total:0.##}");
            Console.WriteLine($"Balance after payment {customer.Balance:0.##}\n");

            cart.Products.Clear();
        }
    }
}
