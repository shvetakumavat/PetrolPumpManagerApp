using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpDBLibrary.Model
{
    public class MeterReading
    {
        public int ID { get; set; }
      
        public decimal OpeningReading { get; set; }
      
        public decimal ClosingReading { get; set; }
        public DateTime Date { get; set; }

        public int StaffId { get; set; }
        public string StaffName { get; set; }
 
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public  int  NozzelId { get; set; }
        public string  NozzelName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal SaleInLeters { get; set; }
 
        public decimal NetSale { get; set; }
   
        public decimal Test { get; set; }
 
        public decimal SaleAmount { get; set; }
  
        public decimal TotalSalesInLeter { get; set; }
   
        public decimal TotalSalesAmount { get; set; }
    }
}
