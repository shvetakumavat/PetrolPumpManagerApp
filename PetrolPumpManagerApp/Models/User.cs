using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.Models
{
    public class User
    {
        [Required(ErrorMessage = "UserName is required")]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Pleas Enter your First Name")]
        [Display(Name = "Frist Name")]
        public string FristName { get; set; }

        [Required(ErrorMessage = "Pleas Enter your Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Pleas Enter your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Pleas Enter your Password")]
        [Display(Name = "Confirmed Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password Not Match")]
        public string ConfirmedPassword { get; set; }

        [Required(ErrorMessage = "Pleas Enter your Email Address")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string  EmailAddress { get; set; }
    }
}