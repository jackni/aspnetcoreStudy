using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Models
{
    public class SalesDiscountRequest
    {
        [Required]
        public int DiscountId { get; set; }

        [Required]
        public decimal SalesPrice { get; set; }
    }
}
