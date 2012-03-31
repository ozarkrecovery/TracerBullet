using System;
using System.Collections.Generic;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Web.Controllers
{
    public class CounselorController : Controller
    {
        public ActionResult Index()
        {
            return View(new List<Patient>
                {
                    new Patient {Id = 1}
                });
        }

        public ActionResult Show(string username)
        {
            return Content("Coming soon");
        }
    }
}