using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpDBLibrary.Model
{
    public class Tanker
    {
        public int TankerID { get; set; }
        public string TankerName { get; set; }
        public decimal Capacity { get; set; }
        public decimal MinmumDip { get; set; }
        public decimal MaximumDip { get; set; }
    }
}
