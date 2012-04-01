using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Web.Controllers
{
    [Authorize]
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

        protected RedirectResult Redirect<T>(Expression<Action<T>> action, object extraRouteValues = null) where T : Controller
        {
            return Redirect(Request.RequestContext.GetUrl(action, extraRouteValues));
        }
	}
}
