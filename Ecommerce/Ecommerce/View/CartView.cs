using Ecommerce.Model;
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

        //public void DisplayShipmentNotice(IEnumerable<IShippable> products)
        //{
        //    Console.WriteLine("** Shipment notice **");


        //    // Group by product name 
        //    var grouped = products
        //      .GroupBy(x => x.Name)
        //      .Select(g => new {
        //          Name = g.Key,
        //          Count = g.Count(),
        //          Weight = g.First().Weight  
        //      });

        //    foreach (var g in grouped)
        //    {
        //        var totalGrams = g.Weight * 1000 * g.Count;
        //        Console.WriteLine($"{g.Count}x {g.Name} {totalGrams} g");
        //    }

        //    var totalWeight = products.Sum(x => x.Weight);
        //    Console.WriteLine($"Total package weight {totalWeight:#0,00} kg");
        //}


        public void DisplayShipmentNotice(IEnumerable<Product> products)
        {
            Console.WriteLine("** Shipment notice **");
            var shippables = products.OfType<IShippable>();
            foreach (var g in shippables
                         .GroupBy(p => p.Name)
                         .Select(g => (Name: g.Key, Count: g.Count(), Wt: g.First().Weight)))
            {
                var grams = g.Wt * 1000 * g.Count;
                Console.WriteLine($"{g.Count}x {g.Name} {grams}g");
            }
            var totalKg = shippables.Sum(p => p.Weight);
            Console.WriteLine($"Total package weight {totalKg:F1}kg");

            Console.WriteLine();
        }
        public void DisplayReceipt(bool ok, string msg, double sub, double fee, double total)
        {
            Console.WriteLine("** Checkout Receipt **");
            Console.WriteLine($"Subtotal:{sub:C}");
            Console.WriteLine($"Shipping:{fee:C}");
            Console.WriteLine($"Amount:{total:C}");
            Console.WriteLine(msg);
        }

        
    }
}
