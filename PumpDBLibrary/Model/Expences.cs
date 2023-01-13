using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpDBLibrary.Model
{
    public class Expences
    {
        public int ID { get; set; }
        public int  StaffId { get; set; }
        public string  StaffName { get; set; }
        public string Remark { get; set; }
        public Decimal Amount { get; set; }
    }
}
