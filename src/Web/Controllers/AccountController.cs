using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;
using OzarkRecovery.Core.Services;

namespace OzarkRecovery.Web.Controllers
{
    public class AccountController : Controller
    {
        private IRepository _repository = null;
        private ISecurityContextService _securityContext = null;

        public AccountController(IRepository repository, ISecurityContextService securityContext)
        {
            _repository = repository;
            _securityContext = securityContext;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            User user = _repository.Find<User>(x => x.Username.Equals(login.Email))
                                  .FirstOrDefault();
            if (null == user)
            {
                login.ErrorMessage = "Email not recognized. Please note email is case sensitive.";
                return View(login);
            }

            if (!login.Password.Equals(user.Password))
            {
                login.ErrorMessage = string.Format("Password does not match the one on record for {0}. Please note password is case sensitive", login.Email);
            }

            _securityContext.Create(user.Username);

            return View("Home");
        }

    }
}
