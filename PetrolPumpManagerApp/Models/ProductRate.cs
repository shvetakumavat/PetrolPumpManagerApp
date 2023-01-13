using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.Models
{
    public class ProductRate
    {
        public int RateId { get; set; }
        public int  ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Varience { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Date { get; set; }
        public Decimal Rate { get; set; }
    }
}