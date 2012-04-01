using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;
using OzarkRecovery.Web.Models;

namespace OzarkRecovery.Web.Controllers
{
    public class CounselorController : BaseController
    {
        public CounselorController(IRepository repository) : base(repository)
        {
        }

        public ActionResult Index()
        {
            return View(new CounselorIndexModel
                {
                    IsAdmin = WhoAmI().IsSupervisor,
                    Counselors = _repository
                        .Find<Counselor>(x => x.IsActive)
                        .Select(x => new {x.Id, x.FirstName, x.LastName, ActiveClients = x.Treatments.Count()})
                        .ToArray()
                        .Select(x => new CounselorIndexModel.CounselorModel {Id = x.Id, Name = string.Format("{0} {1}", x.FirstName, x.LastName).Trim(), ActiveClients = x.ActiveClients})
                        .ToArray()
                });
        }

        public ActionResult Show(int id)
        {
            var counselor = _repository.Find<Counselor>(x => x.Id == id).SingleOrDefault();
            if (counselor == null)
                return Redirect<CounselorController>(c => c.Index());

            //ViewBag.Treatments[0].ClientId = 1;
            //ViewBag.Treatments[0].TreatmentNumber = 1;
            //ViewBag.Treatments[0].ClientName = "Jane Fonda";
            //ViewBag.Treatments[0].CurrentStep = "Treatment Planning";

            //ViewBag.Treatments[1].ClientId = 2;
            //ViewBag.Treatments[1].TreatmentNumber = 1;
            //ViewBag.Treatments[1].ClientName = "Tom Hanks";
            //ViewBag.Treatments[1].CurrentStep = "Intake / Screaning";

            //ViewBag.Treatments[2].ClientId = 3;
            //ViewBag.Treatments[2].TreatmentNumber = 3;
            //ViewBag.Treatments[2].ClientName = "The Hulk";
            //ViewBag.Treatments[2].CurrentStep = "Treatment Implementation";

            var user = WhoAmI();

            return View(new CounselorShowModel
                {
                    CanAddTreatment = user.IsSupervisor || user.Id == counselor.Id,
                    CounselorName = counselor.FullName,
                    AssignedClients = counselor
                        .Treatments
                        .Select(x => new CounselorShowModel.ClientModel
                            {
                                Id = x.Client.Id,
                                Name = x.Client.FullName,
                                TreatmentNumber = counselor.Treatments.IndexOf(x),
                                CurrentStep = x.CurrentStep
                            })
                        .ToArray()
                });
        }

        public ActionResult Add()
        {
            return View(new CounselorAddModel());
        }
    }
}