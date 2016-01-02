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

        private const string DEFAULT_CATALOG_FILE_NAME = @".\productList.json";
        private const string DEFAULT_CHECKOUT_PRODUCT = "mbp, hdm, nx9";

        public CheckoutFormPresenter(ICatalogService catalogService,
                                     ICheckoutService checkoutService)
        {
            this.CatalogService = catalogService;
            this.CheckoutService = checkoutService;

            View = new CheckoutForm(DEFAULT_CATALOG_FILE_NAME);
            View.CheckoutProduct = DEFAULT_CHECKOUT_PRODUCT;
            View.CatalogChanged += View_CatalogChanged;
            View.importCatalog();

            View.CalculateTotal += View_CalculateTotal;
        }

        private void View_CalculateTotal(object sender, string[] checkoutList)
        {
            IList<IProduct> receipt = new List<IProduct>();
            View.TotalCost = CheckoutService.Total(checkoutList, ref receipt);
            StringBuilder receiptText = new StringBuilder();
            foreach (IProduct product in receipt)
            {
                receiptText.AppendLine(product.Properties["SKU"] + ": " + product.Properties["Price"]);
            }
            View.Receipt = receiptText.ToString();
        }

        private void View_CatalogChanged(object sender)
        {
            CatalogService.populateCatalog(View.CatalogContent);
        }
    }
}
