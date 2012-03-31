using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Web.Controllers
{
    [Authorize]
    public class CounselorController : BaseController
    {
        public CounselorController(IRepository repository) : base(repository)
        {
        }

        public ActionResult Index()
        {
            //ViewBag.User = WhoAmI();
            //ViewBag.Counselors = _repository.Find<Counselor>(x => x.IsActive == true);
            ViewBag.User = new Counselor {Id = 1234, FullName = "Johnny Supervisor", IsActive = true, IsSupervisor = true, Password = "abc", UserName = "jsupe"};
            ViewBag.Counselors = new List<Counselor>
                                     {
                                         new Counselor
                                             {
                                                 Id = 1,
                                                 FullName = "Jane Doe",
                                                 IsActive = true,
                                                 IsSupervisor = false,
                                                 Password = "abc",
                                                 UserName = "jadoe",
                                                 Programs = new List<Program>()
                                          
                                             },
                                         new Counselor
                                             {
                                                 Id = 2,
                                                 FullName = "John Doe",
                                                 IsActive = true,
                                                 IsSupervisor = true,
                                                 Password = "abc",
                                                 UserName = "jodoe",
                                                 Programs = new List<Program>()
                                             },
                                         new Counselor
                                             {
                                                 Id = 3,
                                                 FullName = "Jane Smith",
                                                 IsActive = true,
                                                 IsSupervisor = true,
                                                 Password = "abc",
                                                 UserName = "jasmith",
                                                 Programs = new List<Program>()
                                             },
                                         new Counselor
                                             {
                                                 Id = 4,
                                                 FullName = "John Smith",
                                                 IsActive = true,
                                                 IsSupervisor = true,
                                                 Password = "abc",
                                                 UserName = "josmith",
                                                 Programs = new List<Program>()
                                             }
                                     };

            return View();
        }

        public ActionResult Show(string username)
        {
            //var counselor = _repository.Find<Counselor>(x => x.UserName == username).SingleOrDefault();
            //if (counselor == null)
            //    return Redirect<CounselorController>(c => c.Index());

            ViewBag.CounselorName = username.ToUpper();
            ViewBag.Programs = new[]
                {
                    new ExpandoObject(),
                    new ExpandoObject(),
                    new ExpandoObject(),
                };

            ViewBag.Programs[0].Id = 1;
            ViewBag.Programs[0].ClientName = "Jane Fonda";
            ViewBag.Programs[0].CurrentPhase = "Treatment Planning";

            ViewBag.Programs[1].Id = 2;
            ViewBag.Programs[1].ClientName = "Tom Hanks";
            ViewBag.Programs[1].CurrentPhase = "Intake / Screaning";

            ViewBag.Programs[2].Id = 3;
            ViewBag.Programs[2].ClientName = "The Hulk";
            ViewBag.Programs[2].CurrentPhase = "Treatment Implementation";

            return View();
        }

        public ActionResult Add()
        {
            return Content("Coming soon");
        }
    }
}