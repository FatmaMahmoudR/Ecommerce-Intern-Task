using Ecommerce.Controller;
using Ecommerce.Model;
using Ecommerce.Services;
using Ecommerce.Services.Interfaces;
using Ecommerce.View;
using Ecommerce.View.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace Ecommerce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Register services and views
            var services = new ServiceCollection();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IShippingService, ShippingService>();
            services.AddScoped<ICartService, CartService>();

            services.AddSingleton<IProductView, ProductView>();
            services.AddSingleton<ICartView, CartView>();

            services.AddScoped<ProductController>();
            services.AddScoped<CartController>();


            var provider = services.BuildServiceProvider();

            //Display all products
            var productController = provider.GetRequiredService<ProductController>();
            productController.ShowAll();
            Console.WriteLine();

            // Add products to cart
            var cartController = provider.GetRequiredService<CartController>();
            cartController.Add("Cheese", 2);
            cartController.Add("TV", 1);
            cartController.Add("Biscuits", 1);
            cartController.Add("Scratch Card", 1);
            Console.WriteLine();


            // Checkout
            var customer = new Customer(1, "Ali", 1000);
            cartController.Checkout(customer);
        }

    }
    
}
