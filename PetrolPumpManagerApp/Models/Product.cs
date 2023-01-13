using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public  string ProductName { get; set; }
        public decimal Stock { get; set; }
        public bool Active { get; set; }
      
    }
}