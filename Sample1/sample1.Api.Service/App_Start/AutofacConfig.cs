using Autofac;
using Autofac.Extras.NLog;
using Autofac.Features.Metadata;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.WebApi;
using Codenesium.Foundation.CommonMVC;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using sample1NS.Api.Contracts;
namespace sample1NS.Api.Service
{
    public class AutofacConfig
    {
        public static void ConfigureWebAPIContainer()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            builder.RegisterModule<NLogModule>();
            builder.RegisterModule<SimpleNLogModule>();

            builder.RegisterType<Model1>().As(typeof(DbContext));

            builder.RegisterModule(new ValidationModule(
            BuildManager.GetGlobalAsaxType()
           .BaseType.Assembly.GetTypes()
           .Where(x => x.Name.EndsWith("Validator")).ToList()));

            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource(
  t => !(t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Meta<>))));
            // Set the dependency resolver to be Autofac.

            
			
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}