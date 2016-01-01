using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Interfaces;

namespace Rules.Interfaces
{
    public interface IPricingRules
    {
        List<IProduct> applyPricingRules(List<IProduct> productBasket, ICatalogService catalogService);
    }
}