using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Interfaces;

namespace Model.Interfaces
{
    public interface ICatalogService
    {
        void populateCatalog(string json);

        IProduct getProduct(string sku);


    }
}
