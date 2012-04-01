using System;
using System.ComponentModel.DataAnnotations;

namespace OzarkRecovery.Web.Models
{
    public class CounselorAddModel
    {
        [Required, Display(Description = "First Name")]
        public string FirstName { get; set; }

        [Required, Display(Description = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, Display(Description = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Description = "Administrator")]
        public bool IsAdmin { get; set; }
    }
}