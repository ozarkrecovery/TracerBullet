using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Model;
using OzarkRecovery.Core.Domain.Interfaces;

namespace OzarkRecovery.Web.Controllers
{
    public class CounselorController : BaseController
    {
        public CounselorController(IRepository repository) : base(repository) { }

        public ActionResult Index()
		{
		    //ViewBag.User = WhoAmI();
		    //ViewBag.Counselors = _repository.Find<Counselor>(x => x.IsActive == true);
            ViewBag.User = new Counselor{ Id=1234, FullName = "Johnny Supervisor", IsActive=true, IsSupervisor=true, Password="abc", UserName="jsupe"};
            ViewBag.Counselors = new List<Counselor>
                                     {
                                         new Counselor
                                             {
                                                 Id = 1,
                                                 FullName = "Jane Doe",
                                                 IsActive = true,
                                                 IsSupervisor = false,
                                                 Password = "abc",
                                                 UserName = "jadoe"
                                             },
                                         new Counselor
                                             {
                                                 Id = 2,
                                                 FullName = "John Doe",
                                                 IsActive = true,
                                                 IsSupervisor = true,
                                                 Password = "abc",
                                                 UserName = "jodoe"
                                             },
                                         new Counselor
                                             {
                                                 Id = 3,
                                                 FullName = "Jane Smith",
                                                 IsActive = true,
                                                 IsSupervisor = true,
                                                 Password = "abc",
                                                 UserName = "jasmith"
                                             },
                                         new Counselor
                                             {
                                                 Id = 4,
                                                 FullName = "John Smith",
                                                 IsActive = true,
                                                 IsSupervisor = true,
                                                 Password = "abc",
                                                 UserName = "josmith"
                                             }
                                     };
            return View();
        }

        public ActionResult Show(string username)
        {
            var counselor = _repository.Find<Counselor>(x => x.UserName == username).SingleOrDefault();
            if (counselor == null)
                return Redirect<CounselorController>(c => c.Index());

            return View(counselor);
        }
    }
}