using PetrolPumpManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.ViewModels
{
    public class SalesManModel
    {
        public int staffId { get; set; }
        public string  StaffName { get; set; }
        public decimal TSaleAmount { get; set; }
        public decimal TSale { get; set; }
        public List<MeterReading> sale = new List<MeterReading>();
       
    
    }
}