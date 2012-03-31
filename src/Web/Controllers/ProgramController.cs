using System;
using System.Web.Mvc;

namespace OzarkRecovery.Web.Controllers
{
    public class ProgramController : Controller
    {
        public ActionResult Index()
        {
            return Content("List of all (active only?) programs coming soon...");
        }

        public ActionResult Show(int id)
        {
            return Content("Detail view of program coming soon... " + id);
        }
    }
}