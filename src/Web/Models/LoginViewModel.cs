using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OzarkRecovery.Web.Controllers
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {

        }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }

    }
}
