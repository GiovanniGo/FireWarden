using Model.Interfaces;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presenter;
using Service.Interfaces;
using Rules.Interfaces;
using Rules;

namespace NABDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ICatalog catalog = new Catalog();
            ICatalogService catalogService = new CatalogService(catalog);
            IPricingRules pricingRules = new PricingRules();
            ICheckoutService checkoutService = new CheckoutService(pricingRules, catalogService);
            CheckoutFormPresenter formPresenter = new CheckoutFormPresenter(catalogService, checkoutService);

            Application.Run(formPresenter.View);
        }
    }
}
