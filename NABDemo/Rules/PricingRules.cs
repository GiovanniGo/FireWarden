using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Interfaces;
using System.Linq.Expressions;
using Rules.Interfaces;
namespace Rules
{
    // PricingRules class is dependency injected to the CheckoutService and compiled as 
    // a separate dll. As such, this should satisfy the requirement that a change in rules
    // can be deployed to quickly (i.e. swapping to a newer rules dlls)

    // The complexity of the applyPricingRules is N. I kept it simple with cost. The product list is being traversed
    // more than once and may have performance impact. There are of course other ways that would
    // require the function to pass the basket just once but may not be worth it given that
    // pricing rules tendency to change (i.e a more tailored algorithm is not ideal as it may be
    // dependent on the set of rules at a give time. A change of rule in the set may nullify the algorithm)
    public class PricingRules : IPricingRules
    {
        private const int NEXUS9_MIN_DISCOUNT_ITEM = 4;
        private const string PRICE_KEY = "Price";
        private const string SKU_KEY = "SKU";
        public List<IProduct> applyPricingRules(List<IProduct> productBasket, 
                                                ICatalogService catalogService)
        {
            List<IProduct> discountedProductBasket = productBasket;


            //Buy three pay for two Apple TV Deal
            int appleTVCount = 0;
            foreach(IProduct appleTVProduct in discountedProductBasket.Where(x => x.Properties[SKU_KEY] == "atv"))
            {
                appleTVCount++;
                if (appleTVCount % 3 == 0)
                {
                    appleTVProduct.Properties[PRICE_KEY] = 0;
                }
            }

            //Nexus9 discount
            // If nx9 is more than four pieces, set all the prices for nx9 to $499.99
            if (discountedProductBasket.Count(x => x.Properties[SKU_KEY] == "nx9") > NEXUS9_MIN_DISCOUNT_ITEM)
            {
                discountedProductBasket.Where(x => x.Properties[SKU_KEY] == "nx9").ToList().
                    ForEach(y => y.Properties[PRICE_KEY] = 499.99);
            }

            //MacBook Pro + HDMI adapter bundle
            //Count the number of mbp and add hdm with zero cost
            int mbpCount = discountedProductBasket.Count(x => x.Properties[SKU_KEY] == "mbp");
            int hdmCount = discountedProductBasket.Count(x => x.Properties[SKU_KEY] == "hdm");

            // Apply discount to existing HDMI cables for the number of mbp purchased
            int appliedDiscount = 0;
            while (appliedDiscount < mbpCount &&
                  discountedProductBasket.Count(x => x.Properties[SKU_KEY] == "hdm"
                                                && x.Properties[PRICE_KEY] > 0) > 0) 
            {
                appliedDiscount++;
                discountedProductBasket.First(x => x.Properties[SKU_KEY] == "hdm"
                                                   && x.Properties[PRICE_KEY] > 0).Properties[PRICE_KEY] = 0;
            }

            // Bundle hdmi cables for each mbp that are standalone
            if (hdmCount < mbpCount)
            {
                int bonusHDMICount = mbpCount - hdmCount;
                for (int i = 0; i < bonusHDMICount; i++)
                {
                    IProduct cable = catalogService.getProduct("hdm");
                    cable.Properties[PRICE_KEY] = 0;
                    discountedProductBasket.Add(cable);
                }
            }

            return discountedProductBasket;
        }
    }

}
