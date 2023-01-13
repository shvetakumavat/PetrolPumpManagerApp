using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.Models
{
    public class TankerDip
    {
        public int Id { get; set; }
        public Tanker Tanker { get; set; }
        public decimal MinDip { get; set; }
        public decimal MaxDip { get; set; }
        public DateTime Date { get; set; }
    }
}