using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "Must enter Screen Name.")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]{5,11}", ErrorMessage = "Invalid Screen Name.")]
        [Display(Name = "Screen Name")]
        public string ScreenName { get; set; }

        [Required(ErrorMessage = "Must enter Email.")]// msdn.microsoft.com/en-us/library/01escwtf(v=vs.100).aspx
        [RegularExpression(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
            ErrorMessage ="Invalid Email.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        // TODO - Make sure Passwords get hashed.
        [Required(ErrorMessage = "Must enter Password.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Must confirm Password.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        // TODO - Need this "default constructor" for methods later...? look into.
        public RegisterUserViewModel()
        {
        }
    }
}
