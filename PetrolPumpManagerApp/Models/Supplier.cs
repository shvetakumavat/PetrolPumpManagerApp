using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.Models
{
    public class Supplier
    {

        public int SupplierID { get; set; }

        [Required(ErrorMessage ="Pease enter the name of supplier")]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Please enter the email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please specify the supplier address city and state")]
        public string Address { get; set; }
        [Display(Name ="Contact Number")]
        [Required(ErrorMessage = "Please enter contact number")]
        public string ContactNumber  { get; set; }

        public string  Remark { get; set; }
    }
}