using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Services;
using NetCoreWebApi.Models;

namespace NetCoreWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SalePriceDemoController : Controller
    {
        private readonly IItemPriceService _itemPriceService;
        public SalePriceDemoController(IItemPriceService itemPriceService)
        {
            _itemPriceService = itemPriceService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ItemPriceResponse), 200)]
        [ProducesResponseType(typeof(ItemPriceResponse), 400)]
        [Route("GetItemBasePrice")]
        public IActionResult GetItemBasePrice([FromBody]ItemPriceRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            SalesItem item = _itemPriceService.GetSalesItem(request.Id);

            return Ok(new ItemPriceResponse {
                Id = item.Id,
                BasePrice = item.SalesPrice,
                SalesPrice = 0,
                Cost = item.Cost,
                Name = item.Name
            });
        }

        [HttpGet]
        [Route("GetAvailableDiscount")]
        public IActionResult GetAvailableDiscount()
        {
            List<SalesDiscount> discounts = _itemPriceService.GetDiscounts();
            return Ok(discounts);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SalesDiscountResponse), 200)]
        [ProducesResponseType(typeof(SalesDiscountResponse), 400)]
        [Route("GetDiscount")]
        public IActionResult GetDiscountPrice([FromBody]SalesDiscountRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            SalesDiscount discount = _itemPriceService.GetDiscount(request.DiscountId);
            SalesDiscountResponse result = new SalesDiscountResponse { SalesPrice = request.SalesPrice * (1- discount.Discount) };
            return Ok(result);
        }
    }
}