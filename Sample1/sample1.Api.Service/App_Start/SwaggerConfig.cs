
using System.Web.Http;
using WebActivatorEx;
using Swashbuckle.Application;



namespace sample1NS.Api.Service
{
    public class SwaggerConfig
    {
         public static void Register(HttpConfiguration config)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            config.EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "sample1.Api.Service");
                    c.ApiKey("ApiKey")
                     .Name("Authorization")
                     .In("header");
                })
            .EnableSwaggerUi(c =>
                {
                    c.EnableApiKeySupport("Authorization", "header");
                });
        }
    }
}