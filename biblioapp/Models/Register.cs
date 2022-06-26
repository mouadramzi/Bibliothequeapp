using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using biblioapp.Models;
using System.ComponentModel.DataAnnotations;
 

namespace biblioapp.Models
{
    public class Register  
    {



        [Key]
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}