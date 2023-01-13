using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpDBLibrary.Model
{
    public class ProductRate
    {
        public int RateId { get; set; }
        public int ProductId { get; set; }
        public  string ProductName { get; set; }
        public DateTime Date { get; set; }
        public Decimal Rate { get; set; }
    }
}
