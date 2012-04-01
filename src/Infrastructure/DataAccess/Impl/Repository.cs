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
        private ORContext _context;

        public Repository(DbContext c)
        {
            _context = c as ORContext;
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
