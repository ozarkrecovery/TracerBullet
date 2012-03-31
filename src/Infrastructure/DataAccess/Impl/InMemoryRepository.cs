using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;
using System.Linq.Expressions;

namespace OzarkRecovery.Infrastructure.DataAccess.Impl
{
    public class InMemoryRepository<TSource> : IRepository where TSource:Entity
    {
        private IList<User> users = new List<User>() { new User() { Password = "blah", Username = "tjosbon" } };

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : Entity
        {
            var type = typeof(T);

            if (type == typeof(User))
                return (IQueryable<T>)users.AsQueryable<User>();

            throw new ArgumentException(string.Format("Unknown type '{0}'", type));
        }

       
 
    }
}
