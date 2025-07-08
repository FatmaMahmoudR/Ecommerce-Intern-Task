using Ecommerce.Model;
using Ecommerce.Services.Interfaces;
using Ecommerce.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Controller
{
    internal class ProductController
    {
        private readonly IProductService _service;
        private readonly IProductView _view;

        public ProductController(IProductService svc, IProductView view)
        {
            _service = svc;
            _view = view;
        }

        public void ShowAll()
        {
            _view.DisplayAll(_service.ShowAll());
        }
    }
}
