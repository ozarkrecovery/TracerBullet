using System;
using System.Configuration;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LowercaseRoutesMVC;

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

            routes.MapRouteLowercase("about", "about", new {controller = "Home", action = "About"});
            routes.MapRouteLowercase("Default", "{controller}/{action}/{id}", new {controller = "Home", action = "Index", id = UrlParameter.Optional});
        }

        protected void Application_Start()
        {
            var productionVersion = ConfigurationManager.AppSettings["ProductionVersion"];
            Application["version"] = !string.IsNullOrEmpty(productionVersion) ? productionVersion : Assembly.GetExecutingAssembly().GetName().Version.ToString();

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}