using System;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Interfaces;

namespace OzarkRecovery.Web.Controllers
{

    public class SupervisorController : BaseController
    {
        public SupervisorController(IRepository repository)
            : base(repository)
        {
                
        }
        public ActionResult Index()
        {
            return Content("Supervisor list coming soon");
        }
    }
}