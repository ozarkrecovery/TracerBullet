using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;
using System.Linq.Expressions;

namespace OzarkRecovery.Infrastructure.DependencyResolution
{
    public class InMemoryRepository : IRepository
    {
        IList<User> users = new List<User>() { { new User() { Username = "tjosbon", Password = "tjosbon@ozarkrecovery.com" } } };
        public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : Entity
        {
            var type = typeof(T);

            if (type == typeof(User))
                return (IQueryable<T>)users.AsQueryable<User>();

            throw new ArgumentException(string.Format("Invalid type {0}", type));
        }
    }
}
