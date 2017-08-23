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

namespace sample1NS.Api.Service
{
    public static class WebApiConfig
    {
	    public static string ApiKey { get; set; }

        public static void Register(HttpConfiguration config)
        {
            var cors = new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*");
            config.EnableCors();
            // Web API configuration and services
            // Use camel case for JSON data.
            config.Formatters.Remove(config.Formatters.XmlFormatter); //remove default xml formatter.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

		    config.MapHttpAttributeRoutes(new CustomDirectRouteProvider());

            config.Routes.MapHttpRoute(
                name: "DefaultApiWithAction",
                routeTemplate: "api/{controller}/{action}/{id}",
                constraints: new { action = @"[a-zA-Z]+"},
                defaults: new { id = RouteParameter.Optional}
            );

            config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                 routeTemplate: "api/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );
			 
	   	     WebApiConfig.ApiKey = ConfigurationManager.AppSettings["ApiKey"].ToString();

			 config.Filters.Add(new ApiKeyFilter());
        }

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
                if (WebApiConfig.ApiKey != suppliedApiKey)
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
}