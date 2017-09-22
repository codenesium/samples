using System;
using System.Configuration;
using System.Web.Http;
using Codenesium.Foundation.CommonMVC;
using JsonPatch.Formatting;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using NLog;
using Owin;


namespace FileServiceNS.Api.Service
{
    public class Startup
    {
        public static string ApiKey { get; set; }
	    Logger _logger = LogManager.GetCurrentClassLogger();
       
	    public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll); // allow requests from everywhere

            var config = new HttpConfiguration();

			config.MessageHandlers.Add(new LoggingHandler(_logger)); // logs all requests to the console when trace logging enabled

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

			SwaggerConfig.Register(config);

            config.Formatters.Remove(config.Formatters.XmlFormatter); //remove default xml formatter.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // Use camel case for JSON data.
            config.MapHttpAttributeRoutes(new CustomDirectRouteProvider()); // makes routes on abstract controllers work

            config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                 routeTemplate: "api/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );

            config.Formatters.Add(new JsonPatchFormatter()); // enables patching of models

			// Secure all methods in the app with a very simple API key that must be passed
			// prefixed with the work BASIC. Example BASIC <your_api_key>.
			// This is not sufficient for a production system. OAuth is your best bet. 
			// Comment out these lines to remove all security from your API. 
            Startup.ApiKey = ConfigurationManager.AppSettings["ApiKey"].ToString();
            config.Filters.Add(new ApiKeyFilter());

            // add webapi to the owin pipeline
			app.UseWebApi(config);

            // call the startup in the api project to complete registrations
            AutofacConfig.ConfigureWebAPIContainerSelfHost(app, config);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            // OAuthBearerAuthenticationOptions OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            // app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }
    }
}