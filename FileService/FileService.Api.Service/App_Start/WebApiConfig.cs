using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;

namespace FileServiceNS.Api.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			//Enable CORS
            var cors = new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*");
            config.EnableCors();

            // Use camel case for JSON data.
            config.Formatters.Remove(config.Formatters.XmlFormatter); //remove default xml formatter.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

		    config.MapHttpAttributeRoutes(new CustomDirectRouteProvider());

            config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                 routeTemplate: "api/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );
			 

	   	     Startup.ApiKey = ConfigurationManager.AppSettings["ApiKey"].ToString();

			 //Secure API by default with simple key
			 config.Filters.Add(new ApiKeyFilter());
        }
	}

	//Ths provider makes routes work with a base controller and a child class that inherits
	public class CustomDirectRouteProvider : DefaultDirectRouteProvider
    {
        protected override IReadOnlyList<IDirectRouteFactory>
        GetActionRouteFactories(HttpActionDescriptor actionDescriptor)
        {
            // inherit route attributes decorated on base class controller's actions
            return actionDescriptor.GetCustomAttributes<IDirectRouteFactory>
            (inherit: true);
        }
    }

		
    public class ApiKeyFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var suppliedApiKey = actionContext.Request.Headers.Authorization?.Parameter;
            if (Startup.ApiKey != suppliedApiKey)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Invalid Api Key. Key must be passed with auth type like 'Basic <your_key>'" };
                throw new HttpResponseException(response);
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}