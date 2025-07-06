using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    internal class ShippingService
    {
        public decimal ShippingFee(double totalWeight) => (decimal)totalWeight * 2.5m;

    }
}
