using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Infrastructure.DataAccess.Impl;

namespace OzarkRecovery.Infrastructure.DependencyResolution
{
	public class BootStrapper
	{
		public static void RegisterIoC()
		{
			ObjectFactory.Initialize(x =>
			{
				x.For<IRepository>().Use<Repository>();

			});
		}
	}
}
