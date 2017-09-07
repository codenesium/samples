using System;
using System.Configuration;
using System.Web.Http;
using JsonPatch.Formatting;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;

namespace NebulaNS.Api.Service
{
    public class Startup
    {
        public static string ApiKey { get; set; }
		
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var config = new HttpConfiguration();

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API configuration and services
            // Use camel case for JSON data.
            config.Formatters.Remove(config.Formatters.XmlFormatter); //remove default xml formatter.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.MapHttpAttributeRoutes(new CustomDirectRouteProvider());

            config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                 routeTemplate: "api/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );

            config.Formatters.Add(new JsonPatchFormatter());

            Startup.ApiKey = ConfigurationManager.AppSettings["ApiKey"].ToString();
            config.Filters.Add(new ApiKeyFilter());

            app.UseWebApi(config);

            //call the startup in the api project to complete registrations
            AutofacConfig.ConfigureWebAPIContainerSelfHost(app, config);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            //OAuthBearerAuthenticationOptions OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            //app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }
    }
}