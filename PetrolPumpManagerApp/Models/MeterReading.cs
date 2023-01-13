using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.Models
{
    public class MeterReading
    {
        public int ID { get; set; }
        [Display(Name = "Opening Readings")]
        public decimal OpeningReading { get; set; }
        [Display(Name = "Closing Readings")]
        public decimal ClosingReading { get; set; }

        [DisplayFormat(DataFormatString = "{0: yyyy MMM dd }")]
        public DateTime Date { get; set; }

        [Display(Name ="SalesMan")]
        public int StaffId { get; set; }
  
        public int  MachineId { get; set; }
        public string  MachineName { get; set; }
        [Display(Name ="Fuil Type")]
        public int NozzelId { get; set; }
        public string NozzelName { get; set; }
        public  int ProductId { get; set; }
        public string ProductName { get; set; }
        [Display(Name = "Sales")]
        public decimal HSDRate  { get; set; }
        public decimal MSDRate { get; set; }
        public decimal SaleInLeters { get; set; }
        [Display(Name = "Net Sales")]
        public decimal NetSale { get; set; }
        [Display(Name = "Test")]
        public decimal Test { get; set; }
        [Display(Name = "Amount")]
        public decimal SaleAmount { get; set; }
        [Display(Name = "Total Sales In Leter")]
        public decimal TotalSalesInLeter { get; set; }
        [Display(Name = "Total Sales In Rupess")]
        public decimal TotalSalesAmount { get; set; }
    }
}