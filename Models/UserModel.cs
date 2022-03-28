using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VotingWebApp2._0.Models
{
    public class UserModel
    {
        
        
        //Variables to link to the user table on the database.  
        public int UserID { get; set; }

        //Data annotation which allow to modify the model. 
        [Display(Name = "First name")]
        [Required(ErrorMessage = "First Name is required.")]
        public string firstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string lastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email is required.")]
        public string email { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirm email address")]
        [Compare("EmailAddress", ErrorMessage = "Email and Confrim email must match.")]
        [Required(ErrorMessage = "Confirm email is required.")]
        public string confirmEmail { get; set; }
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be between 8 - 100 characters.")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Pasword is required.")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and Confrim password must match.")]
        [Required(ErrorMessage = "Confirm email is required.")]
        public string confirmPassword { get; set; }

    }
}