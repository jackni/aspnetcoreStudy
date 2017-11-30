using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Models
{
    public class ItemPriceRequest
    {
        [Required]
        public int Id { get; set; }

    }
}
