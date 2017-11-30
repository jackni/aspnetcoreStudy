using NetCoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.DemoData
{
    public static class ItemPriceDemoData
    {
        public static List<SalesItem> GetSalesItems()
        {
            var items = new List<SalesItem>
            {
                new SalesItem{Id=1, Name="xbox one", Cost=200, SalesPrice=310m},
                new SalesItem{Id=2, Name="ps4", Cost=300, SalesPrice=420.95m},
                new SalesItem{Id=3, Name="Wii", Cost=100, SalesPrice=220m}
            };
            return items;
        }

        public static List<SalesDiscount> GetDiscounts()
        {
            var discounts = new List<SalesDiscount>
            {
                new SalesDiscount{Id=1, Name="special customer discount", Discount = 0.1m},
                new SalesDiscount{Id=2, Name="holiday special", Discount = 0.3m},
                new SalesDiscount{Id=3, Name="clearance special", Discount = 0.6m}

            };
            return discounts;
        }
    }
}
