using System;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Interfaces;

namespace OzarkRecovery.Web.Controllers
{

    public class HomeController : BaseController
    {
        public HomeController(IRepository repository) : base(repository)
        {

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}