﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMvcProject.Models
{
    public class AdminRegistrationModel
    {
        [DataType(DataType.EmailAddress)]
        [Required, EmailAddress(ErrorMessage ="Invalid email address.")]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage ="Password and Confirm Password must match.")]
        public string ConfirmPassword { get; set; }

      
    }
}
