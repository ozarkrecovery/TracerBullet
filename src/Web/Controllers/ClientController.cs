using System;
using System.Linq;
using System.Web.Mvc;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;
using OzarkRecovery.Web.Models;

namespace OzarkRecovery.Web.Controllers
{

    public class ClientController : BaseController
    {
        public ClientController(IRepository repository) : base(repository)
        {
        }

        public ActionResult Index()
        {
            return View(new ClientIndexModel{
                Clients = _repository
                        .Find<Client>(x => x.FirstName != null)
                        .Select(x => new { x.Id, x.FirstName, x.LastName })
                        .ToArray()
                        .Select(x => new ClientIndexModel.ClientModel { Id = x.Id, Name = string.Format("{0} {1}", x.FirstName, x.LastName).Trim() })
                        .ToArray()
            });
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

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ClientAddModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(new Client
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                });

                _repository.Commit();

                return Redirect<ClientController>(c => c.Index());
            }

            return View(model);
        }

    }
}