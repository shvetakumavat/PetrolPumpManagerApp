using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.Models
{
    public class Expences
    {
        public int  ExpenceID { get; set; }
        public int StaffId { get; set; }
        public string  StaffName { get; set; }
        public string Remark { get; set; }
        public Decimal Amount { get; set; }
    }
}