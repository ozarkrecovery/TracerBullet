using System;
using System.Linq;
using System.Linq.Expressions;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Core.Domain.Interfaces
{
    public interface IRepository
    {
        T Get<T>(int id) where T : Entity;
        T Get<T>(Expression<Func<T, bool>> predicate) where T : Entity;

        IQueryable<T> Find<T>() where T : Entity;
        IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : Entity;

        void Add<T>(T newentry) where T : Entity;
        void Delete<T>(T entity) where T : Entity;

        void Commit();
    }
}