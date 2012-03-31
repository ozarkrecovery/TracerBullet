using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Infrastructure.DataAccess.Impl
{
    class ClientRepository : IRepository
    {

        ClientRepository(ORContext c)
        {
            Context = c;
        }
        public ORContext Context { get; set; }
        public Entity FindByEntityId(int id)
        {
            var patient = Context.Patient.Where(p => p.Id == id);
            return ((Entity)patient);            
        }

        public List<Client> FindByName(string name)
        {
            var patients = Context.Patient.Where(p => p.LastName.Contains(name)).ToList();
            return patients;            
        }

        public List<Entity> GetAll()
        {
            var allPatient = Context.Patient.Cast<Entity>().ToList();
            return allPatient;
        }

        public void Update(Entity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Client patient = (Client) FindByEntityId(id);
            Context.Patient.Remove(patient);
        }

        public void Add(Client entity)
        {
           
        }
    }
}
