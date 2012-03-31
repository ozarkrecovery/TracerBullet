using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;


namespace OzarkRecovery.Infrastructure.DataAccess.Impl
{
    public class Repository : IRepository
    {
        private ORContext context;

        public Repository(ORContext c)
        {
            context = c;
        }

        //public List<T> Find<T>(Expression<Func<T, bool>> predicate) where T : Entity
        //{
        //    return context.Query<T>().Where(predicate);
        //}

        public Entity FindByEntityId(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Entity> FindByLastName(string name)
        {
            throw new System.NotImplementedException();
        }

        public List<Entity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Entity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Entity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}