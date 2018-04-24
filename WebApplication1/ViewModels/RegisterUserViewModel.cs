using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "Must choose Screen Name.")]
        [Display(Name = "Screen Name")]
        public string ScreenName { get; set; }

        [Required(ErrorMessage = "Must enter Email.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        // TODO - Make sure Passwords get hashed.
        [Required(ErrorMessage = "Must enter Password.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Phonenumber (Optional)")]
        public string PhoneNumber { get; set; }

        // TODO - Need this "default constructor" for methods later...? look into.
        public RegisterUserViewModel()
        {
        }
    }
}
