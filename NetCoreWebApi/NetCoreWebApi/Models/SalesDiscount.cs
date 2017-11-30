using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Models
{
    public class SalesDiscount
    {
        public int Id { get; set; }

        //public int SalesItemId { get; set; }

        public string Name { get; set; }

        [Range(0, 0.99)]
        public decimal Discount { get; set; }
    }
}
