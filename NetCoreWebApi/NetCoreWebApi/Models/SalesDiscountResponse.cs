using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Models
{
    public class SalesDiscountResponse
    {
        [JsonProperty("salesPrice")]
        public decimal SalesPrice { get; set; }
    }
}
