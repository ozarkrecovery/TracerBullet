using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OzarkRecovery.Core.Domain.Model;
using System.Linq.Expressions;

namespace OzarkRecovery.Core.Domain.Interfaces
{
	public interface IRepository
	{
		IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : Entity;
	}
}
