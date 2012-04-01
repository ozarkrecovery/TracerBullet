using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Web.Controllers
{
    public class DocumentController : BaseController
    {
        public DocumentController(IRepository repository) : base(repository) { }
        
        [ChildActionOnly]
        public ActionResult Widget(IList<Document> documents)
        {
            return View(documents);
        }

    }
}
