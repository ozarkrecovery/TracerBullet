using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Web.Controllers
{
	public class BaseController : Controller
	{
		protected IRepository _repository { get; private set; }
		public BaseController(IRepository repository)
		{
			_repository = repository;
		}

        public Counselor WhoAmI()
        {
            var userid = ControllerContext.HttpContext.User.Identity.Name;
            return _repository.Find<Counselor>(x => x.UserName == userid).FirstOrDefault();
        }
	}
}
