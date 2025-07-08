using Ecommerce.Controller;
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

            services.AddSingleton<IProductView, ProductView>();
            services.AddSingleton<ICartView, CartView>();

            services.AddScoped<ProductController>();


            var provider = services.BuildServiceProvider();

            //Display all products
            var prodController = provider.GetRequiredService<ProductController>();
            prodController.ShowAll();
            Console.WriteLine();




        }

    }
    
}
