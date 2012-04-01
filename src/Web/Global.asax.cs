using System;
using System.Configuration;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LowercaseRoutesMVC;
using OzarkRecovery.Infrastructure.DependencyResolution;
using OzarkRecovery.Web;
using StructureMap;

namespace Web
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRouteLowercase("supervisor", "supervisor/{id}/{action}", new {controller = "supervisor", action = "show"}, new {id = @"^\d?$"});
            routes.MapRouteLowercase("counselor", "counselor/{id}/{action}", new {controller = "counselor", action = "show"}, new {id = @"^\d?$"});
            routes.MapRouteLowercase("treatment", "client/{clientId}/treatment-{treatmentNumber}/{action}", new {controller = "treatment", action = "show"}, new {clientId = @"^\d?$"});
            routes.MapRouteLowercase("client", "client/{id}/{action}", new {controller = "client", action = "show"}, new {id = @"^\d?$"});

            routes.MapRouteLowercase("home about", "about", new {controller = "home", action = "about"});

            routes.MapRouteLowercase("Default", "{controller}/{action}/{id}", new {controller = "home", action = "index", id = UrlParameter.Optional});
        }

        protected void Application_Start()
        {
            var productionVersion = ConfigurationManager.AppSettings["ProductionVersion"];
            Application["version"] = !string.IsNullOrEmpty(productionVersion) ? productionVersion : Assembly.GetExecutingAssembly().GetName().Version.ToString();

            AreaRegistration.RegisterAllAreas();
            BootStrapper.RegisterIoC();
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}