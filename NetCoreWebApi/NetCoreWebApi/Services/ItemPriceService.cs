using NetCoreWebApi.DemoData;
using NetCoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Services
{
    public class ItemPriceService : IItemPriceService
    {
        public SalesItem GetSalesItem(int itemId)
        {
            return ItemPriceDemoData.GetSalesItems().SingleOrDefault(i => i.Id == itemId);
        }

        public List<SalesDiscount> GetDiscounts()
        {
            return ItemPriceDemoData.GetDiscounts();
        }

        public SalesDiscount GetDiscount(int discountId)
        {
            return ItemPriceDemoData.GetDiscounts().SingleOrDefault(d => d.Id == discountId);
        }
    }
}
