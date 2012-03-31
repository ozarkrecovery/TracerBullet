using System;
using System.Collections.Generic;
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
			return View(new List<Client>
                {
                    new Client {Id = 1}
                });
		}
	}
}