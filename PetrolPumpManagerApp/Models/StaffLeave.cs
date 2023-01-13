using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.Models
{
    public class StaffLeave
    {
        public int ID { get; set; }

        [Display(Name ="Staff")]
        public  List<Staff> Staff{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveReason { get; set; }
    }
}