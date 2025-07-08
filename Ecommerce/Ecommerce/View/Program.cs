using Ecommerce.Controller;
using Ecommerce.Model;
using Ecommerce.Services;

namespace Ecommerce.View
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Initialize products 
            var stock = new List<Product>{
            new ExpirableShippableProduct("Cheese", 100, 5, DateTime.Today.AddDays(7), 0.2),
            new ExpirableShippableProduct("Biscuits",150,3, DateTime.Today.AddDays(10),0.7),
            new ShippableProduct("TV",  500,20,2.5),
            new Product("Scratch Card", 50, 10)
            };

            // Initialize services and controller objects
            var shipService = new ShippingService();
            var cartController = new CartController(stock, shipService);
            var productController = new ProductController(stock);
            var customer = new Customer { Id = 1, Name = "Fatma", Balance = 2000 };
            var customerController = new CustomerController();
            var cart = new Cart {};



            // Display all products
            productController.ShowAll();

            Console.WriteLine();

            // Display customer details
            customerController.details(customer);

            Console.WriteLine();

            // Add products to cart
            cartController.AddToCart(cart, "Cheese", 2);
            cartController.AddToCart(cart, "Biscuits", 1);
            cartController.AddToCart(cart, "TV", 1);
            cartController.AddToCart(cart, "Scratch Card", 2);
            cartController.Checkout(customer, cart);


            var customer2 = new Customer { Id = 1, Name = "Ahmed", Balance = 2000 };
            //var cart2 = new Cart { Id = 2 };

        }

    }
    
}
