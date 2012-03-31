using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using System.Data.Entity;


namespace OzarkRecovery.Infrastructure.DataAccess.Impl
{
    public class Repository : IRepository
    {
        private DbContext context;

        public Repository(DbContext c)
        {
            context = c;
        }

        public List<T> Find<T>(Expression<Func<T, bool>> predicate) where T : Entity
        {
            //return context.Get<T>().Where(predicate);
            return context.Get<T>();
        }

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