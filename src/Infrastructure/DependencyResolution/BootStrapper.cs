using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Infrastructure.DataAccess.Impl;
using System.Data.Entity;
using OzarkRecovery.Infrastructure.DataAccess;

namespace OzarkRecovery.Infrastructure.DependencyResolution
{
	public class BootStrapper
	{
		public static void RegisterIoC()
		{
            Database.SetInitializer<ORContext>(new DropCreateDatabaseIfModelChanges<ORContext>());
			ObjectFactory.Initialize(x =>
			{
				x.For<IRepository>().Use<Repository>();
			    x.For<DbContext>().Use<ORContext>();
			});
		}
	}
}
