using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface ICatalog
    {
        Dictionary<string, IProduct> ProductList { get; }

        void populate(string catalogJson);
    }
}
