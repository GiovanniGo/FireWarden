using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Interfaces;
namespace Model
{
    public class Product : Interfaces.IProduct
    {
        public const string KeyName = "SKU";
        public IDictionary<string, dynamic> Properties { get; set; }

        object ICloneable.Clone()
        {
            Product copyProduct = new Product();
            copyProduct.Properties = new Dictionary<string, dynamic>(this.Properties);
            return copyProduct;
        }
    }
}
