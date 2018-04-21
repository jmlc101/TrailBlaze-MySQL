using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class LogOnViewModel
    {
        [Required(ErrorMessage = "Must enter Email.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        // TODO - Make sure Passwords get hashed.
        // TODO - Where can I add Password Validations?
        [Required(ErrorMessage = "Must enter Password.")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
