﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OzarkRecovery.Web.Controllers
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {

        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public string ErrorMessage { get; set; }
    }
}
