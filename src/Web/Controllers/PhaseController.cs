using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Web.Controllers
{
    public class PhaseController : BaseController
    {
        public PhaseController(IRepository repository) : base(repository) { }
        
        [ChildActionOnly]
        public ActionResult Widget(IList<Phase> phases)
        {
            return View(phases);
        }

    }
}
