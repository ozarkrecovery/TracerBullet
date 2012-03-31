using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using ExpressionHelper = Microsoft.Web.Mvc.Internal.ExpressionHelper;

namespace OzarkRecovery.Web
{
    public static class MvcExtensions
    {
        public static string GetUrl(this RequestContext context, RouteValueDictionary routeValues)
        {
            var virtualPath = RouteTable.Routes.GetVirtualPath(context, routeValues).VirtualPath;
            return new Uri(context.HttpContext.Request.Url, virtualPath).AbsoluteUri;
        }

        public static string GetUrl(this RequestContext context, object routeValues)
        {
            return context.GetUrl(new RouteValueDictionary(routeValues));
        }

        public static string GetUrl(this RequestContext context, RouteValueDictionary routeValues, object extraRouteValues)
        {
            foreach (var extraValue in new RouteValueDictionary(extraRouteValues))
                routeValues[extraValue.Key] = extraValue.Value;
            return context.GetUrl(routeValues);
        }

        public static string GetUrl<TController>(this RequestContext context, Expression<Action<TController>> action) where TController : Controller
        {
            return context.GetUrl(ExpressionHelper.GetRouteValuesFromExpression(action));
        }

        public static string GetUrl<TController>(this RequestContext context, Expression<Action<TController>> action, object extraRouteValues) where TController : Controller
        {
            return context.GetUrl(ExpressionHelper.GetRouteValuesFromExpression(action), extraRouteValues);
        }
    }
}