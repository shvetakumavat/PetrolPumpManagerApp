using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpDBLibrary.Model
{
    public class PurchaseProduct
    {
        public int PurchaseId { get; set; }
        public int ProductsId { get; set; }
        public string ProductName { get; set; }
        public int SuppliersId { get; set; }
        public string SupplierName { get; set; }
 
        public int TankersId { get; set; }
        public string TankerName { get; set; }
        public DateTime Date { get; set; }
        public decimal Quantity { get; set; }
        public decimal PurchaseAmount { get; set; }
        public string Remark { get; set; }
    }
}
