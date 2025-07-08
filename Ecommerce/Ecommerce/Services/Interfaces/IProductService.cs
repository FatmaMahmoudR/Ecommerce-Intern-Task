using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interfaces
{
    internal interface IProductService
    {
        IEnumerable<Product> ShowAll();
    }
}
