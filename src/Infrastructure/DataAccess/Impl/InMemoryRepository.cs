using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;
using System.Linq.Expressions;

namespace OzarkRecovery.Infrastructure.DataAccess.Impl
{
    public class InMemoryRepository : IRepository
    {
        IList<User> users = new List<User>() { { new User() { Username = "tjosbon@ozarkrecovery.com", Password = "tjosbon" } },
                                               { new User() { Username = "rtennyson@ozarkrecovery.com", Password = "rtennyson" } },
                                               { new User() { Username = "admin", Password = "admin" } }
                                             };
        public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : Entity
        {
            var type = typeof(T);

            if (type == typeof(User))
                return (IQueryable<T>)users.Where<User>((Func<User, bool>)predicate.Compile()).AsQueryable<User>();

            throw new ArgumentException(string.Format("Invalid type {0}", type));
        }
    }
}
