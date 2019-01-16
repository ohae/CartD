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
    public class CartController : ControllerBase
    {
        public static Cart MyCart = new Cart
        {
            Products = new List<AddProduct>
            {
                new AddProduct { _id = "001", Name = "iPhoneXS Max", Price = 40000, Quantity = 6 }
            }
        };

        // GET api/values
        [HttpGet(Name = "GetCart")]
        public ActionResult<Cart> Get()
        {
            //calculate cost here
            var result = CalculateCartEngine.CalculateCart(MyCart);
            return result;
        }

        // PUT api/values/5
        [HttpPut(Name = "AddProductToCart")]
        public void Put([FromBody] AddProduct product)
        {
            var sysProduct = ProductController.MyProducts.Where(x => x._id == product._id).FirstOrDefault();

            var prd = MyCart.Products.Where(x => x._id == sysProduct._id)?.FirstOrDefault();
            if (prd != null)
            {
                prd.Quantity += product.Quantity;
            }
            else
            {
                MyCart.Products.Add(new AddProduct { _id = sysProduct._id, Name = sysProduct.Name, Price = sysProduct.Price, Quantity = product.Quantity });
            }
        }
    }
}
