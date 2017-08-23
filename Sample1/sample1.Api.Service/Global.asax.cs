using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace sample1NS.Api.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
		    SwaggerConfig.Register(GlobalConfiguration.Configuration);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutofacConfig.ConfigureWebAPIContainer();
        }
    }
}