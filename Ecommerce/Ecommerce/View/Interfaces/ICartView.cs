using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.View.Interfaces
{
    internal interface ICartView
    {
        void DisplayResult(bool ok, string message);

        void DisplayShipmentNotice(IEnumerable<Product> products);
        void DisplayReceipt(bool ok, string message,double subtotal, double fee, double total);



    }
}
