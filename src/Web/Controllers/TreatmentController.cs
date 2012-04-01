﻿using System;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Interfaces;

namespace OzarkRecovery.Web.Controllers
{

    public class TreatmentController : BaseController
    {
        public TreatmentController(IRepository repository) : base(repository)
        {
                
        }
        public ActionResult Index()
        {
            return Content("List of all (active only?) treatments coming soon...");
        }

        public ActionResult Show(int clientId, int treatmentNumber)
        {
            return Content(string.Format("Detail view of treatment coming soon... ({0}, {1})", clientId, treatmentNumber));
        }
    }
}