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
        private DbContext _context;

        public Repository(DbContext c)
        {
            _context = c;
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : Entity
        {
            return _context.Set<T>().Where(predicate);
        }
    }
}
