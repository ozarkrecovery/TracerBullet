using System;
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
                return Redirect<CounselorController>(c => c.Index(), new {id = ""});

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
                                TreatmentNumber = counselor.Treatments.IndexOf(x) + 1,
                                CurrentStep = x.CurrentStep.Name
                            })
                        .ToArray()
                });
        }

        public ActionResult Add()
        {
            return View(new CounselorAddModel());
        }

        [HttpPost]
        public ActionResult Add(CounselorAddModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.ConfirmPassword)
                    ModelState.AddModelError("ConfirmPassword", "Passwords must match");
                else
                {
                    _repository.Add(new Counselor
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            UserName = model.Username,
                            Password = model.Password,
                            IsSupervisor = model.IsAdmin,
                            IsActive = true,
                        });

                    _repository.Commit();

                    return Redirect<CounselorController>(c => c.Index());
                }
            }

            model.Password = model.ConfirmPassword = "";

            return View(model);
        }
    }
}