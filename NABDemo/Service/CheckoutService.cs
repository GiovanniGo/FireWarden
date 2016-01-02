using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Interfaces;
using Rules.Interfaces;
using Service.Interfaces;
namespace Service
{
    public class CheckoutService : ICheckoutService
    {
        private IPricingRules pricingRules;
        private ICatalogService catalogService;

        public CheckoutService(IPricingRules pricingRules, ICatalogService catalogService)
        {
            this.pricingRules = pricingRules;
            this.catalogService = catalogService;
        }

        public double Total(string[] skuList, ref IList<IProduct> receipt)
        {
            List<IProduct> productBasket = new List<IProduct>();
            foreach (string sku in skuList)
            {
                IProduct product = catalogService.getProduct(sku.Trim());
                if (product != null && product.Properties.Count > 0)
                {
                    productBasket.Add(product);
                }
            }

            List<IProduct> discountedProductBasket = 
                pricingRules.applyPricingRules(productBasket, catalogService);

            double totalCost = discountedProductBasket.Sum(x => (double)x.Properties["Price"]);
            receipt = discountedProductBasket;
            return totalCost;
        }
    }
}
