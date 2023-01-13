using PetrolPumpManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.ViewModels
{
    public class SaleIndexViewModel
    {
        public List<SalesManModel> SalesMan = new List<SalesManModel>();
        public List<MeterReading> meterReading = new List<MeterReading>();
    }
}