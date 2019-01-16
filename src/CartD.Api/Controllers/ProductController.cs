using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartD.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CartD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<ProductBase> MyProducts = new List<ProductBase>
        {
            new ProductBase{ _id = "001", Name = "iPhone XS Max", Price = 40000 },
            new ProductBase{ _id = "002", Name = "iPhone XR", Price = 20000 },
        };

        // GET api/values
        [HttpGet(Name = "ListProducts")]
        public ActionResult<IEnumerable<ProductBase>> Get()
        {
            return MyProducts;
        }

        // POST api/values
        [HttpPost(Name = "AddProduct")]
        public void Post([FromBody] ProductBase product)
        {
            MyProducts.Add(product);
        }
    }
}
