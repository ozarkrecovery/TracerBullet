using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Web.Controllers
{
    public class SurveyController : BaseController
    {
        public SurveyController(IRepository repository) : base(repository) { }
        
        [ChildActionOnly]
        public ActionResult Widget(IList<Survey> surveys)
        {
            return View(surveys);
        }

    }
}
