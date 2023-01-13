using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.Models
{
    public class Machine
    {
        public int MachineID { get; set; }
        [Display(Name = "Machine Number")]
        [Required(ErrorMessage ="Machine number is required")]
        public int MachineNumber { get; set; }
        [Display(Name ="Machine Name/ Company Name")]
        [Required(ErrorMessage = "Machine Name is required")]
        public string MachineName { get; set; }

        //TODO- fuil Type feild not mantioned in db
        public string FuilType { get; set; }
    }
}