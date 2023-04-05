using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDomain.ViewModels.AuthModels
{
    public class RegisterModel
    {
        //[Required(ErrorMessage = "Username is required")]
        //public string Username { get; set; }


        //[EmailAddress]
        //[StringLength(50, MinimumLength = 5)]
        //[Required(ErrorMessage = "Email is required")]
        //public string Email { get; set; }


        //[StringLength(50, MinimumLength = 5)]
        //[Required(ErrorMessage = "Password is required")]
        ////[DataType(DataType.Password)]
        //public string Password { get; set; }


        //[StringLength(50, MinimumLength = 5)]
        //[Required(ErrorMessage = "Confirm Password is required")]
        ////[DataType(DataType.Password)]
        ////[Compare("Password",ErrorMessage ="Password and confirmation password do not match")]
        //public string ConfirmPassword { get; set; }



        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "LatLong")]
        public string LatLong { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
