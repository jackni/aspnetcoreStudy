using System.Collections.Generic;
using NetCoreWebApi.Models;

namespace NetCoreWebApi.Services
{
    public interface IItemPriceService
    {
        List<SalesDiscount> GetDiscounts();
        SalesDiscount GetDiscount(int discountId);
        SalesItem GetSalesItem(int itemId);
    }
}