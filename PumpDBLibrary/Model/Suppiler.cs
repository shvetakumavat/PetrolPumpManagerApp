using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpDBLibrary.Model
{

        public class Supplier
        {
            public int SupplierID { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string ContactNumber { get; set; }
            public string Remark { get; set; }
        }
    
}
