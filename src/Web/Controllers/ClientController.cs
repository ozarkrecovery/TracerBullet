using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Web.Controllers
{
	public class ClientController : BaseController
	{
		public ClientController(IRepository repository) : base(repository) { }
		
		public ActionResult Edit(int id)
		{
			_repository.Find<Client>(x => x.Id == id).FirstOrDefault();
			return View();
		}
	}
}
