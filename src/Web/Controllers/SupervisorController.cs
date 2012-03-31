using System;
using System.Web.Mvc;

namespace OzarkRecovery.Web.Controllers
{
    [Authorize]
    public class SupervisorController : Controller
    {
        public ActionResult Index()
        {
            return Content("Supervisor list coming soon");
        }
    }
}