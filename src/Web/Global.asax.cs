﻿using System;
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

            routes.MapRouteLowercase("counselor show", "counselor/{username}/{action}", new {controller = "counselor", action = "show"});
            routes.MapRouteLowercase("supervisor show", "supervisor/{username}/{action}", new {controller = "supervisor", action = "show"});
            routes.MapRouteLowercase("client show", "client/{username}/{action}", new {controller = "client", action = "show"});

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