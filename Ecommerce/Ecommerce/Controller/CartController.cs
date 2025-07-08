using Ecommerce.Model;
using Ecommerce.Services;
using Ecommerce.Services.Interfaces;
using Ecommerce.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Controller
{
    internal class CartController
    {
        private readonly ICartService _service;
        private readonly ICartView _view;
        public CartController(ICartService svc, ICartView view)
        { _service = svc; _view = view; }

        public void Add(string name, int qty)
        {
            var (ok, msg) = _service.AddToCart(name, qty);
            _view.DisplayResult(ok, msg);
        }

        public void Checkout(Customer customer)
        {
            var (ok, msg, sub, fee, total) = _service.Checkout(customer);
            var items = _service.GetAllProducts();

            _view.DisplayShipmentNotice(items);
            _view.DisplayReceipt(ok, msg, sub, fee, total);
        }
    }
}
