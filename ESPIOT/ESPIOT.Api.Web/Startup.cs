using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.Metadata;
using Autofac.Features.ResolveAnything;
using Codenesium.Foundation.CommonMVC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.Services;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public Startup()
        {
        }

        public IContainer ApplicationApiContainer { get; protected set; }

        public IConfigurationRoot Configuration { get; protected set; }

        public static readonly LoggerFactory LoggerFactory
            = new LoggerFactory(new List<ILoggerProvider>()
            {
                new ConsoleLoggerProvider((category, level)
                => 
                category == DbLoggerCategory.Database.Command.Name
                   && level == LogLevel.Information, true),

                 new DebugLoggerProvider((category, level)
                => category == DbLoggerCategory.Database.Command.Name
                   && level == LogLevel.Information)
            });

        public virtual DbContextOptions SetupDatabase(bool enableSensitiveDataLogging)
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            if (enableSensitiveDataLogging)
            {
                options.EnableSensitiveDataLogging();
            }

            options.UseLoggerFactory(Startup.LoggerFactory);
            options.UseSqlServer(this.Configuration.GetConnectionString(nameof(ApplicationDbContext)));
            
			// options.UseNpgsql(this.Configuration.GetConnectionString(nameof(ApplicationDbContext))); uncomment to use PostgreSQL
            return options.Options;
        }

        public virtual void MigrateDatabase(ApplicationDbContext context)
        {
            if (this.Configuration.GetValue<bool>("MigrateDatabase"))
            {
                context.Database.Migrate();
            }
        }

        public virtual void SetupLogging(IServiceCollection services)
        {
            services.AddLogging(logBuilder => logBuilder
                .AddConfiguration(this.Configuration.GetSection("Logging"))
                .AddConsole()
                .AddDebug());
        }

        public virtual void SetupAuthentication(IServiceCollection services)
        {
            if (this.Configuration.GetValue<bool>("SecurityEnabled"))
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
        }

		/// <summary>
		/// Set up authorization and require the SuperUser claim in order to access
		/// the API. If SecurityEnabled is set to false in the appsettings then disable all 
		/// authorization.
		/// </summary>
		/// <param name="services"></param>
		public virtual void SetupAuthorization(IServiceCollection services)
		{
			if (this.Configuration.GetValue<bool>("SecurityEnabled"))
			{
				services.AddAuthorization(options =>
				{
				    // set up the DefaultAccess to require an authenticated user only
					// this can be modified to require claims or roles
					options.AddPolicy("DefaultAccess", policy =>
									  	policy.RequireAuthenticatedUser());
				});
			}
			else
			{
				services.AddAuthorization(options =>
				{
					// remove the requirement that a user be authenticated
					options.DefaultPolicy = new AuthorizationPolicyBuilder()
				   .RequireAssertion(_ => true)
				   .Build();

				    // set up the DefaultAccess policy to always allow access
					options.AddPolicy("DefaultAccess", policy =>
					 policy.RequireAssertion(_ => true));
				});
			}
		}

        public virtual void EnableSecurity(IApplicationBuilder app)
        {
            if (this.Configuration.GetValue<bool>("SecurityEnabled"))
            {
                 app.UseAuthentication();
            }
        }

        // ConfigureServices is where you register dependencies. This gets
        // called by the runtime before the Configure method, below.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
           services.Configure<ApiSettings>(this.Configuration);

           services.AddCors(config =>
           {
                var policy = new CorsPolicy();
                policy.Headers.Add("*");
                policy.Methods.Add("*");
                policy.Origins.Add("*");
                policy.SupportsCredentials = true;
                config.AddPolicy("AllowAll", policy);
            });

            services.AddMvcCore(config =>
            {
                if (this.Configuration.GetValue<bool>("SecurityEnabled"))
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

            // Enable MVC for app and disable the built in model validation
            // We're disabling the built in validation because we're using Fluent Valdidation to 
            // handle it. 
            services.AddMvc(options => options.ModelValidatorProviders.Clear());

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
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    o.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                }

                // add a custom operation filter which sets default values
                o.OperationFilter<SwaggerDefaultValues>();

                // integrate xml comments
                // o.IncludeXmlComments( XmlCommentsFilePath );
                if (this.Configuration.GetValue<bool>("SecurityEnabled"))
                {
                   var security = new Dictionary<string, IEnumerable<string>>
                   {
                        {"Bearer", new string[] { }},
                   };
                   o.AddSecurityRequirement(security);
                   o.AddSecurityDefinition("Bearer", new ApiKeyScheme() { In = "header", Description = "Please insert JWT prefixed with Bearer", Name = "Authorization", Type = "apiKey" });
                }
            });

            this.SetupLogging(services);

            this.SetupAuthentication(services);

			this.SetupAuthorization(services);

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

            // register the global settings object
            builder.Register(ctx => ctx.Resolve<IOptions<ApiSettings>>().Value);

            // create entity framework options
            DbContextOptions dbOptions = this.SetupDatabase(true);

            // register the entity framework options
            builder.Register(c => dbOptions).As<DbContextOptions>();

			// register the ApplicationDbContext
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerLifetimeScope();

            // register the ApplicationDbContext as DbContext for anywhere we interact with DbContext like the TransactionCoordinator
            builder.RegisterType<ApplicationDbContext>().As<DbContext>().InstancePerLifetimeScope();

            // Set up the transaction coordinator for Entity Framework
            builder.RegisterType<EntityFrameworkTransactionCoordinator>()
                .As<ITransactionCoordinator>()
                .InstancePerLifetimeScope();
            
            // register mappers in the contracts assembly
            var contractsAssembly = typeof(AbstractApiServerRequestModel).Assembly;
            builder.RegisterAssemblyTypes(contractsAssembly)
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Mapper"))
                .AsImplementedInterfaces()
                .PropertiesAutowired();
            
            // register services, model validators and mappers in the services assembly
            var servicesAssembly = typeof(AbstractService).Assembly;
            builder.RegisterAssemblyTypes(servicesAssembly)
                .Where(t => t.IsClass && !t.IsAbstract && (t.Name.EndsWith("Service") || t.Name.EndsWith("ModelValidator") || t.Name.EndsWith("Mapper")))
                .AsImplementedInterfaces()
                .PropertiesAutowired();

            // register repositories in the data access assembly
            var dataAccessAssembly = typeof(AbstractRepository).Assembly;
            builder.RegisterAssemblyTypes(dataAccessAssembly)
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            // Register anything else we might have that isn't a system, Microsoft, Abstract or Generic class
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource(
                t =>
                    !t.FullName.StartsWith("System") &&
                    !t.FullName.StartsWith("Microsoft") &&
                    !t.IsAbstract &&
                    !(t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Meta<>)))
            );

            // build the DI container
            this.ApplicationApiContainer = builder.Build();
            return new AutofacServiceProvider(this.ApplicationApiContainer);
        }

        // Configure is where you add middleware. This is called after
        // ConfigureServices. You can use IApplicationBuilder.ApplicationServices
        // here if you need to resolve things from the container.
        public void Configure(
          IHostingEnvironment env,
          IApplicationBuilder app,
          ILoggerFactory loggerFactory,
          IApplicationLifetime appLifetime,
          ApplicationDbContext context)
        {
            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            
            loggerFactory.AddDebug();

            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new ExceptionMiddleWare(env, loggerFactory).Invoke
            });

            this.MigrateDatabase(context);

            this.EnableSecurity(app);

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                // remove .. from this line to make the swagger endpoint work from a console app
                // we have this to make it work in IIS with a virtual directory
                // c.SwaggerEndpoint("../swagger/v1/swagger.json", "ESPIOT");
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "ESPIOT");
            });

            app.UseCors("AllowAll");

            app.UseMvc();

            // If you want to dispose of resources that have been resolved in the
            // application container, register for the "ApplicationStopped" event.
            // You can only do this if you have a direct reference to the container,
            // so it won't work with the above ConfigureContainer mechanism.
            appLifetime.ApplicationStopped.Register(() => this.ApplicationApiContainer.Dispose());
        }

        private static string XmlCommentsFilePath
        {
            get
            {
                var basePath = AppContext.BaseDirectory;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }

        private static Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info()
            {
                Title = "ESPIOT API " + description.ApiVersion,
                Version = description.ApiVersion.ToString(),
                Description = "Visit http://editor.swagger.io/ to generate a client for this API",
                TermsOfService = string.Empty,
                License = new License() { Name = "MIT", Url = "https://opensource.org/licenses/MIT" }
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }

    public static class ExceptionMiddleWareExtentions
    {
        public static IApplicationBuilder UseExceptionMiddleWare(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleWare>();
        }
    }

    /// <summary>
    ///  This middleware lets us return errors as a json object intead of html.
    /// </summary>
    public class ExceptionMiddleWare
    {
        private IHostingEnvironment env;

        private ILogger logger;

        public ExceptionMiddleWare(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            this.env = env;
            this.logger = loggerFactory.CreateLogger<ExceptionMiddleWare>();
        }

        public async Task Invoke(HttpContext context)
        {
            Exception ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (ex == null)
            {
                return;
            }
            else
            {
                this.logger.LogError(ex, null);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ApiError error = new ApiError();

                if (this.env.IsDevelopment())
                {
                    error.SetProperties(ex.Message, ex.Source, ex.StackTrace);
                }
                else
                {
                    error.SetProperties("Internal Server Error", string.Empty, string.Empty);
                }

                context.Response.ContentType = "application/json";

                using (var writer = new StreamWriter(context.Response.Body))
                {
                    await writer.FlushAsync().ConfigureAwait(false);
                }
            }
        }
    }

    public class ApiError
    {
        public string Message { get; private set; }

        public string Source { get; private set; }

        public string StackTrace { get; private set; }

        public void SetProperties(string message, string source, string stackTrace)
        {
            this.Message = message;
            this.Source = source;
            this.StackTrace = stackTrace;
        }
    }
}