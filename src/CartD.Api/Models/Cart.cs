using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartD.Api.Models
{
    public class Cart
    {
        public List<AddProduct> Products { get; set; }
        /// <summary>
        /// without discount calculate
        /// </summary>
        public double TotalAmount { get; set; }
        /// <summary>
        /// Buy 3 get 1
        /// </summary>
        public double Discount { get; set; }
        /// <summary>
        /// with discount calculate
        /// </summary>
        public double GrandAmount { get; set; }
    }
}
