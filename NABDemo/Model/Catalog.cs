using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Interfaces;
namespace Model
{
    public class Catalog : ICatalog
    {
        public Dictionary<string, IProduct> ProductList {get;}

        public Catalog()
        {
            ProductList = new Dictionary<string, IProduct>();
          
        }

        public void populate(string catalogJson)
        {
            ProductList.Clear();
            List<Dictionary<string, dynamic>> propertyList
               = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(catalogJson);

            foreach (Dictionary<string, dynamic> properties in propertyList)
            {
                dynamic key = "undefined";
                if (properties.TryGetValue(Product.KeyName, out key))
                {
                    Product newProduct = new Product();
                    newProduct.Properties = properties;
                    ProductList.Add(key, newProduct);
                }
            }
        }
    }
}
