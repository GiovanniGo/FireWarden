using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CatalogService :ICatalogService
    {
        private ICatalog Catalog {get; set; }

        public CatalogService(ICatalog catalog)
        {
            this.Catalog = catalog;
        }

        public void populateCatalog(string json)
        {
            Catalog.populate(json);
        }

        public IProduct getProduct(string sku)
        {
            IProduct product = null;
            IProduct clonedProduct = null;
            if (Catalog.ProductList.TryGetValue(sku, out product))
            {
                clonedProduct = (IProduct)product.Clone();
            }
            return clonedProduct;
        }
    }
}
