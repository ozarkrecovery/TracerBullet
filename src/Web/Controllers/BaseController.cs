using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Interfaces;

namespace OzarkRecovery.Web.Controllers
{
	public class BaseController : Controller
	{
		protected IRepository _repository { get; private set; }
		public BaseController(IRepository repository)
		{
			_repository = repository;
		}

        protected RedirectResult Redirect<T>(Expression<Action<T>> action) where T : Controller
        {
            return Redirect(Request.RequestContext.GetUrl(action));
        }
    }
}
