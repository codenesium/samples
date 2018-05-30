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
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.BusinessObjects;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Service
{
    public class TestStartup
    {
        public TestStartup(IHostingEnvironment env)
        {
           var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; private set; }

        // ConfigureServices is where you register dependencies. This gets
        // called by the runtime before the Configure method, below.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
		    services.Configure<ServiceSettings>(this.Configuration);

			services.AddMvcCore(config =>
            {
                if(this.Configuration.GetValue<bool>("SecurityEnabled"))
				{
					 var policy = new AuthorizationPolicyBuilder()
								  .RequireAuthenticatedUser()
								  .Build();
					 config.Filters.Add(new AuthorizeFilter(policy));
				 }
                 config.Filters.Add(new BenchmarkAttribute());
				 config.Filters.Add(new NullModelValidaterAttribute());
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
				 o.AssumeDefaultVersionWhenUnspecified = true;
                 o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
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
				if(this.Configuration.GetValue<bool>("SecurityEnabled"))
				{
				   var security = new Dictionary<string, IEnumerable<string>>
			       {
						{"Bearer", new string[] { }},
				   };
                   o.AddSecurityRequirement(security);
			       o.AddSecurityDefinition("Bearer", new ApiKeyScheme() { In = "header", Description = "Please insert JWT prefixed with Bearer", Name = "Authorization", Type = "apiKey" });
				}
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

			if(this.Configuration.GetValue<bool>("SecurityEnabled"))
			{
				var key = Encoding.UTF8.GetBytes(this.Configuration["JwtSigningKey"]);
				services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(jwtBearerOptions =>
				{
					jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
					{
						ClockSkew = TimeSpan.FromMinutes(5),
						ValidateAudience = true,
						ValidateIssuer = true,
						ValidateLifetime = true,
						RequireSignedTokens = true,
						RequireExpirationTime = true,
						ValidAudience = this.Configuration["JwtAudience"],
						ValidIssuer = this.Configuration["JwtIssuer"],
						IssuerSigningKey = new SymmetricSecurityKey(key)
					};
				});
			}

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

            builder.Register(ctx => ctx.Resolve<IOptions<ServiceSettings>>().Value);

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


		    var businessObjectsAssembly = typeof(ValidationError).Assembly;
            builder.RegisterAssemblyTypes(businessObjectsAssembly)
                .Where(t => t.IsClass && !t.IsAbstract && (t.Name.StartsWith("BO") || t.Name.EndsWith("ModelValidator")))
                .AsImplementedInterfaces()
				.PropertiesAutowired();


            var dataAccessAssembly = typeof(AbstractRepository).Assembly;
            builder.RegisterAssemblyTypes(dataAccessAssembly)
				.Where(t => t.IsClass && !t.IsAbstract && (t.Name.EndsWith("Repository") || t.Name.EndsWith("Mapper") ))
				.AsImplementedInterfaces();



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
          IApplicationLifetime appLifetime,
	      ApplicationDbContext context)
        {
            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

			if(this.Configuration.GetValue<bool>("SecurityEnabled"))
			{
				 app.UseAuthentication();
		    }

			// Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
				// remove .. from this line to make the swagger endpoint work from a console app
				// we have this to make it work in IIS with a virtual directory
				// c.SwaggerEndpoint("../swagger/v1/swagger.json", "PetShipping");
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "PetShipping");
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
                Title = "PetShipping API " + description.ApiVersion,
                Version = description.ApiVersion.ToString(),
                Description = "Visit https://generator.swagger.io/ to generate a client for this API",
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