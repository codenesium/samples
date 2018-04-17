using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.Metadata;
using Autofac.Features.ResolveAnything;
using Codenesium.Foundation.CommonMVC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Service
{
    public class TestStartup
    {
        public TestStartup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; private set; }

        // ConfigureServices is where you register dependencies. This gets
        // called by the runtime before the Configure method, below.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
			services.AddMvcCore(config =>
            {
                /*
                 var policy = new AuthorizationPolicyBuilder()
                              .RequireAuthenticatedUser()
                              .Build();
                 config.Filters.Add(new AuthorizeFilter(policy));
                 */
                 config.Filters.Add(new BenchmarkFilter());
            }).AddVersionedApiExplorer(
            o =>
            {
                o.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                o.SubstituteApiVersionInUrl = true;
            });

            services.AddMvc();

            services.AddApiVersioning(
             o =>
             {
                 // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                 o.ReportApiVersions = true;
                 o.ApiVersionReader = new HeaderApiVersionReader("api-version");
             });


            services.AddSwaggerGen(o =>
            {
                o.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

				// resolve the IApiVersionDescriptionProvider service
                // note: that we have to build a temporary service provider here because one has not been created yet
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                // add a swagger document for each discovered API version
                // note: you might choose to skip or document deprecated API versions differently
                foreach ( var description in provider.ApiVersionDescriptions )
                {
                    o.SwaggerDoc( description.GroupName, CreateInfoForApiVersion( description ) );
                }

                // add a custom operation filter which sets default values
                o.OperationFilter<SwaggerDefaultValues>();

                // integrate xml comments
                // o.IncludeXmlComments( XmlCommentsFilePath );
				// options.AddSecurityDefinition("Bearer", new ApiKeyScheme() { In = "header", Description = "Please insert token", Name = "Authorization", Type = "apiKey" });
            });


           services.AddCors(config =>
           {
                var policy = new CorsPolicy();
                policy.Headers.Add("*");
                policy.Methods.Add("*");
                policy.Origins.Add("*");
                policy.SupportsCredentials = true;
                config.AddPolicy("policy", policy);
            });

			/*
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    //ValidateActor = true,
                    //ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"]))
                };
            });
			*/

            // Create the container builder.
            var builder = new ContainerBuilder();

            // Register dependencies, populate the services from
            // the collection, and build the container. If you want
            // to dispose of the container at the end of the app,
            // be sure to keep a reference to it as a property or field.
            //
            // Note that Populate is basically a foreach to add things
            // into Autofac that are in the collection. If you register
            // things in Autofac BEFORE Populate then the stuff in the
            // ServiceCollection can override those things; if you register
            // AFTER Populate those registrations can override things
            // in the ServiceCollection. Mix and match as needed.
            builder.Populate(services);

            // set up entity framework options
			DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            options.UseInMemoryDatabase("test");
            ApplicationDbContext context = new ApplicationDbContext(options.Options);
            builder.RegisterInstance(context).As<ApplicationDbContext>();
            builder.RegisterInstance(context).As<DbContext>();

            // Set up the transaction coordinator for Entity Framework
            builder.RegisterType<InMemoryTransactionCoordinator>()
                .As<ITransactionCoordinator>()
                .InstancePerLifetimeScope();


		    builder.RegisterType<ObjectMapper>()
                .As<IObjectMapper>()
                .InstancePerLifetimeScope();

            var dataAccessAssembly = typeof(ObjectMapper).Assembly;
            builder.RegisterAssemblyTypes(dataAccessAssembly)
				.Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Repository"))
				.AsImplementedInterfaces();

            // Register our model validators by convention
           builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                    .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("ModelValidator"))
                    .AsImplementedInterfaces()
                    .AsSelf()
                    .PropertiesAutowired();

            // Register anything else we might have that isn't a system, Microsoft, Abstract or Generic class
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource(
                t =>
                    !t.FullName.StartsWith("System") &&
                    !t.FullName.StartsWith("Microsoft") &&
					!t.IsAbstract &&
                    !(t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Meta<>)))
            );

            this.ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // Configure is where you add middleware. This is called after
        // ConfigureServices. You can use IApplicationBuilder.ApplicationServices
        // here if you need to resolve things from the container.
        public void Configure(
          IApplicationBuilder app,
          ILoggerFactory loggerFactory,
          IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

			// app.UseAuthentication();

			// Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
				// remove .. from this line to make the swagger endpoint work from a console app
				// we have this to make it work in IIS with a virtual directory
				// c.SwaggerEndpoint("../swagger/v1/swagger.json", "ESPIOT");
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "ESPIOT");
            });

            app.UseMvc();

			app.UseDeveloperExceptionPage();

            // If you want to dispose of resources that have been resolved in the
            // application container, register for the "ApplicationStopped" event.
            // You can only do this if you have a direct reference to the container,
            // so it won't work with the above ConfigureContainer mechanism.
            appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
        }

		static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }

        static Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info()
            {
                Title = "ESPIOT API " + description.ApiVersion,
                Version = description.ApiVersion.ToString(),
                Description = "API",
                Contact = new Contact() { Name = "test", Email = "test@test.com" },
                TermsOfService = "",
                License = new License() { Name = "MIT", Url = "https://opensource.org/licenses/MIT" }
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}