using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;


namespace OzarkRecovery.Infrastructure.DataAccess.Impl
{
    public class Repository : IRepository
    {
        private readonly ORContext _context;

        public Repository(DbContext c)
        {
            _context = c as ORContext;
        }

        public T Get<T>(int id) where T : Entity
        {
            return _context.Set<T>().SingleOrDefault(x => x.Id == id);
        }

        public T Get<T>(Expression<Func<T, bool>> predicate) where T : Entity
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public IQueryable<T> Find<T>() where T : Entity
        {
            return _context.Set<T>();
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : Entity
        {
            return _context.Set<T>().Where(predicate);
        }

        public void Add<T>(T newentry) where T : Entity
        {
            _context.Set<T>().Add(newentry);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}