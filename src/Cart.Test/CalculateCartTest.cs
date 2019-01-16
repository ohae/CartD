using CartD.Api;
using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using CartD.Api.Models;

namespace CartD.Test
{
    public class LoadDTest
    {
        [Theory]
        [MemberData(nameof(CalculateCartData))]
        public void CalculateInterest(Cart myCart, Cart expected)
        {
            var result = CalculateCartEngine.CalculateCart(myCart);
            result.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<object[]> CalculateCartData = new List<object[]>
        {
            new object[] { new Cart
                {
                    Products = new List<AddProduct>
                    {
                        new AddProduct { _id = "001", Name = "iPhoneXS Max", Price = 40000, Quantity = 4 }
                    }
                },
                new Cart
                {
                    Products = new List<AddProduct>
                    {
                        new AddProduct { _id = "001", Name = "iPhoneXS Max", Price = 40000, Quantity = 4 }
                    },
                    TotalAmount = 160000,
                    Discount = 40000,
                    GrandAmount = 120000
                },
            },
            new object[] { new Cart
                {
                    Products = new List<AddProduct>
                    {
                        new AddProduct { _id = "001", Name = "iPhoneXS Max", Price = 40000, Quantity = 5 },
                        new AddProduct { _id = "002", Name = "iPhoneXR", Price = 20000, Quantity = 1 }
                    }
                },
                new Cart
                {
                    Products = new List<AddProduct>
                    {
                        new AddProduct { _id = "001", Name = "iPhoneXS Max", Price = 40000, Quantity = 5 },
                        new AddProduct { _id = "002", Name = "iPhoneXR", Price = 20000, Quantity = 1 }
                    },
                    TotalAmount = 220000,
                    Discount = 40000,
                    GrandAmount = 180000
                },
            },
            new object[] { new Cart
                {
                    Products = new List<AddProduct>
                    {
                        new AddProduct { _id = "001", Name = "iPhoneXS Max", Price = 40000, Quantity = 8 }
                    }
                },
                new Cart
                {
                    Products = new List<AddProduct>
                    {
                        new AddProduct { _id = "001", Name = "iPhoneXS Max", Price = 40000, Quantity = 8 }
                    },
                    TotalAmount = 320000,
                    Discount = 80000,
                    GrandAmount = 240000
                },
            },
            new object[] { new Cart
                {
                    Products = new List<AddProduct>
                    {
                        new AddProduct { _id = "001", Name = "iPhoneXS Max", Price = 40000, Quantity = 8 },
                        new AddProduct { _id = "002", Name = "iPhoneXR", Price = 20000, Quantity = 4 }
                    }
                },
                new Cart
                {
                    Products = new List<AddProduct>
                    {
                        new AddProduct { _id = "001", Name = "iPhoneXS Max", Price = 40000, Quantity = 8 },
                        new AddProduct { _id = "002", Name = "iPhoneXR", Price = 20000, Quantity = 4 }
                    },
                    TotalAmount = 400000,
                    Discount = 100000,
                    GrandAmount = 300000
                },
            },
        };
    }
}
