using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICheckoutService
    {
        double Total(string[] skuList, ref IList<IProduct> receipt);
    }
}
