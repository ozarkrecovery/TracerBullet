using System;
using System.Linq;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;
using OzarkRecovery.Core.Services;

namespace OzarkRecovery.Web.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(IRepository repository, ISecurityContextService securityContext)
        {
            _repository = repository;
            _securityContext = securityContext;
        }

        private readonly IRepository _repository;
        private readonly ISecurityContextService _securityContext;

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LoginViewModel login)
        {
            var user = _repository.Find<Counselor>(x => x.UserName == login.Email).SingleOrDefault();
            if (null == user)
            {
                login.ErrorMessage = "Email not recognized. Please note email is case sensitive.";
                return View(login);
            }

            if (!login.Password.Equals(user.Password))
            {
                login.ErrorMessage = string.Format("Password does not match the one on record for {0}. Please note password is case sensitive", login.Email);
                return View(login);
            }

            _securityContext.Create(user.UserName);

            return Redirect(login.ReturnUrl);
        }
    }
}