using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartD.Api.Models
{
    public class GetProductsResponse
    {
        public List<ProductBase> Products { get; set; }
    }
}
