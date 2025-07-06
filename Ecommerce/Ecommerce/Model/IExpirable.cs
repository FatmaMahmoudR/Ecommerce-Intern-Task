using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Model
{
    internal interface IExpirable
    {
        DateTime ExpirationDate { get; }
        bool IsExpired { get; }
    }
}
