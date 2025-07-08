using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.View.Interfaces
{
    internal interface IProductView
    {
        void DisplayAll (IEnumerable<Product> products);

    }
}
