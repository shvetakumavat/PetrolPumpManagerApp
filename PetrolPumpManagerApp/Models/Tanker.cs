using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.Models
{
    public class Tanker
    {
        public int TankerID { get; set; }
        public string  TankerName { get; set; }
        public decimal Capacity { get; set; }

        /// <summary>
        /// dip masurement for warnning about tanker stock
        /// </summary>
        public decimal MinmumDip { get; set; }
        public decimal MaximumDip { get; set; }
    }
}