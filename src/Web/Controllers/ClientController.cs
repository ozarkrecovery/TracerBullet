using System;
using System.Linq;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Web.Controllers
{

    public class ClientController : BaseController
    {
        public ClientController(IRepository repository) : base(repository)
        {
        }

        public ActionResult Index()
        {
            return Content("List of all clients coming soon");
        }

        public ActionResult Show(int id)
        {
            return Content("Client view coming soon... " + id);
        }

        public ActionResult Edit(int id)
        {
            _repository.Find<Client>(x => x.Id == id).FirstOrDefault();
            return View();
        }
    }
}