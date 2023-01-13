using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.Models
{
    public class PurchaseProduct
    {
        public int PurchaseId { get; set; }
        public int ProductsId { get; set; }
        public string ProductName { get; set; }
        public int SuppliersId { get; set; }
        public string SupplierName { get; set; }
        [Display(Name ="Tanker")]
        public int TankersId { get; set; }
        public string TankerName { get; set; }
        public DateTime Date { get; set; }
        public decimal Quantity { get; set; }
        public decimal PurchaseAmount { get; set; }
        public string Remark { get; set; }
    }
}