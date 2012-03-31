using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using OzarkRecovery.Infrastructure.DataAccess.Impl;

namespace OzarkRecovery.Infrastructure.DataAccess
{
	public class NHibernateHelper
	{
		public ISessionFactory BuildSessionFactory() 
		{ 
			return Fluently.Configure()
				.Database(MsSqlConfiguration
					.MsSql2008
					.ConnectionString(c => c.FromConnectionStringWithKey("DBConnectionString"))//.ShowSql()
				).Mappings(mapping => mapping.FluentMappings.AddFromAssemblyOf<Repository>())
				//.ExposeConfiguration(BuildSchema)
				.BuildSessionFactory();
		}
	}
}
