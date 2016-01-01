using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IProduct : ICloneable
    {
        IDictionary<string, dynamic> Properties { get; set; }
    }
}
