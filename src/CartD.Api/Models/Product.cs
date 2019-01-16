using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartD.Api.Models
{
    public class ProductBase
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
