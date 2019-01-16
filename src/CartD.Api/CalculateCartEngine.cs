using CartD.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartD.Api
{
    public static class CalculateCartEngine
    {
        public static Cart CalculateCart(Cart myCart)
        {
            var TotalAmount = 0.0;
            var Discount = 0.0;
            foreach (var product in myCart.Products)
            {
                TotalAmount += product.Quantity * product.Price;

                if (product.Quantity >= 4)
                {
                    var discountQuanity = product.Quantity / 4;
                    //product.Quantity += freeQuanity;
                    Discount += discountQuanity * product.Price;
                }
            }
            var GrandAmount = TotalAmount - Discount;

            myCart.TotalAmount = TotalAmount;
            myCart.Discount = Discount;
            myCart.GrandAmount = GrandAmount;

            return myCart;
        }
    }
}
