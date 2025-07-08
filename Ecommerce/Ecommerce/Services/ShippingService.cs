using Ecommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ecommerce.Services.Interfaces.IShippingService;

namespace Ecommerce.Services
{
    internal class ShippingService : IShippingService
    {
        private const double Rate = 2;
        
        public double ShippingFee(double totalWeight)
        =>  (Rate * totalWeight);
        
    }
}
