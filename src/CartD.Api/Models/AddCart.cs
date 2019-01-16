using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartD.Api.Models
{
    public class AddProduct : ProductBase
    {
        public int Quantity { get; set; }
    }
}
