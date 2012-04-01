using System;
using System.Web;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace OzarkRecovery.Web.Modules
{
	public class ConfigurationModule : IHttpModule
	{
		private static bool isInitialized = false;
		
		public void Init(HttpApplication context)
		{
			context.BeginRequest += BeginRequest;
		}
		
		public void Dispose(){}
		
		public void BeginRequest(object sender, EventArgs args)
		{
			var context = HttpContext.Current;
			var request = context.Request;
			var response = context.Response;
			
			if(ConfigurationIsInitialized(context))
				return;
			
			if(IsResourceRequest(request) && !IsConfigurationRequest(request))
				return;

			if(!IsConfigurationRequest(request))
			{
				response.Redirect("~/Configuration.aspx");
				return;
			}		
			
			if(IsConfigurationGet(request))
				return;
			
			SaveConfiguration(context);

			response.Redirect("~/");
		}
		
		private bool ConfigurationIsInitialized(HttpContext context)
		{
			var configFile = context.Server.MapPath("~/entityFramework.prv");

			return isInitialized |= File.Exists(configFile);
		}
		
		private bool IsResourceRequest(HttpRequest request)
		{
			return !String.IsNullOrEmpty(VirtualPathUtility.GetExtension(request.FilePath));
		}
		private bool IsConfigurationRequest(HttpRequest request)
		{
			return VirtualPathUtility.GetFileName(request.FilePath).Equals("Configuration.aspx");
		}
		
		private bool IsConfigurationGet(HttpRequest request)
		{
			return request.HttpMethod == "GET";
		}
		
		private void SaveConfiguration(HttpContext context)
		{
			var form = context.Request.Form;
			var template = XDocument.Load(context.Server.MapPath("~/entityFramework.template"));
			var configFile = context.Server.MapPath("~/entityFramework.prv");
			
			template
				.Descendants("parameter")
				.FirstOrDefault()
				.Attributes("value")
				.FirstOrDefault()
				.Value = form["connectionString"];
			
			template.Save(configFile);
		}
	}
}
