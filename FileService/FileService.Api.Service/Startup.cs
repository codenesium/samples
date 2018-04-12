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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Service
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
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
			services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "FileService", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

				// c.AddSecurityDefinition("Bearer", new ApiKeyScheme() { In = "header", Description = "Please insert token", Name = "Authorization", Type = "apiKey" });
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

            // Add services to the collection.
            services.AddMvc(config =>
            {
               /*
			    var policy = new AuthorizationPolicyBuilder()
                             .RequireAuthenticatedUser()
                             .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
				*/
            });

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
            options.UseSqlServer(this.Configuration.GetConnectionString(nameof(ApplicationDbContext)));
            ApplicationDbContext context = new ApplicationDbContext(options.Options);
            builder.RegisterInstance(context).As<ApplicationDbContext>();
            builder.RegisterInstance(context).As<DbContext>();

            // Set up the transaction coordinator for Entity Framework
            builder.RegisterType<EntityFrameworkTransactionCoordinator>()
                .As<ITransactionCoordinator>()
                .InstancePerLifetimeScope();

            // AutofacHack is a static empty class we reference to make it possible
            // to get the assembly name in any project without having to look up an assembly
            // dynamically. This section registers repositories by convention.
            var dataAccessAssembly = typeof(AutofacHack).Assembly;
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
				// c.SwaggerEndpoint("../swagger/v1/swagger.json", "FileService");
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "FileService");
            });

            app.UseMvc();

			app.UseDeveloperExceptionPage();

            // If you want to dispose of resources that have been resolved in the
            // application container, register for the "ApplicationStopped" event.
            // You can only do this if you have a direct reference to the container,
            // so it won't work with the above ConfigureContainer mechanism.
            appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
        }
    }
}