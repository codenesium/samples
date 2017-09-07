using Autofac;
using Autofac.Extras.NLog;
using Autofac.Features.Metadata;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.WebApi;
using Codenesium.Foundation.CommonMVC;
using Owin;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Service
{
    public class AutofacConfig
    {
        public static void ConfigureWebAPIContainer()
        {
            var builder = new ContainerBuilder();
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

			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        public static void ConfigureWebAPIContainerSelfHost(IAppBuilder app, HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<NLogModule>();
            builder.RegisterModule<SimpleNLogModule>();

            builder.RegisterType<Model1>().As(typeof(DbContext));

            builder.RegisterModule(new ValidationModule(
              Assembly.GetExecutingAssembly().GetTypes()
             .Where(x => x.Name.EndsWith("Validator")).ToList()));

            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource(
  t => !(t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Meta<>))));

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacWebApi(config);
            app.UseWebApi(config);

        }
	}
}