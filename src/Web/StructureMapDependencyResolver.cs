using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap;

namespace OzarkRecovery.Web
{
	public class StructureMapDependencyResolver : IDependencyResolver
	{
		private IContainer _container { get; set; }
		public StructureMapDependencyResolver(IContainer container) {_container = container; }
		
		public object GetService(Type serviceType)
		{
			if (serviceType.IsAbstract || serviceType.IsInterface)
			{
				return _container.TryGetInstance(serviceType);
			} 
			else
			{
				return _container.GetInstance(serviceType);
			}
		}                
		
		public IEnumerable<object> GetServices(Type serviceType)
		{
			return _container.GetAllInstances<object>().Where(s => s.GetType() == serviceType);
		}
	}
}