using Model.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace Presenter
{
    public class CheckoutFormPresenter
    {
        public CheckoutForm View { get; set; }
        private ICatalogService CatalogService { get; set; }
        private ICheckoutService CheckoutService { get; set; }

        private string defaultCatalogFileName = @".\productList.json";

        public CheckoutFormPresenter(ICatalogService catalogService,
                                     ICheckoutService checkoutService)
        {
            this.CatalogService = catalogService;
            this.CheckoutService = checkoutService;

            View = new CheckoutForm(defaultCatalogFileName);
            View.CatalogChanged += View_CatalogChanged;
            View.importCatalog();

            View.CalculateTotal += View_CalculateTotal;
        }

        private void View_CalculateTotal(object sender, string[] checkoutList)
        {
            View.TotalCost = CheckoutService.Total(checkoutList); 
        }

        private void View_CatalogChanged(object sender)
        {
            CatalogService.populateCatalog(View.CatalogContent);
        }
    }
}
