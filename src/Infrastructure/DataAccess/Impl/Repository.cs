using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OzarkRecovery.Core.Domain.Interfaces;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Infrastructure.DataAccess.Impl
{
	public class Repository : IRepository	{
		
		private ISession _session;
		/*public Repository(ISession session)
		{
			_session = session;
		}*/
		
		public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : Entity
		{
			return _session.Query<T>().Where(predicate);
		}
	}
}
