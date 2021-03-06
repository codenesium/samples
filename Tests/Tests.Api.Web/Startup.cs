using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.Metadata;
using Autofac.Features.ResolveAnything;
using Codenesium.DataConversionExtensions;
using Codenesium.Foundation.CommonMVC;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection;
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
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Polly;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Web
{
    public class Startup
    {
	    private ILoggerFactory loggerFactory;

        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
		    this.loggerFactory = loggerFactory;

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

        public virtual DbContextOptions SetupDatabase(bool enableSensitiveDataLogging)
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();

            if (enableSensitiveDataLogging)
            {
                options.EnableSensitiveDataLogging();
            }

            options.UseLoggerFactory(this.loggerFactory);

			string provider = this.Configuration.GetValue<string>("DatabaseProvider");

            if (provider.ToUpper() == "MSSQL")
			{
				options.UseSqlServer(this.Configuration.GetConnectionString(nameof(ApplicationDbContext)));
			}
			else if (provider.ToUpper() == "POSTGRESQL")
			{
				options.UseNpgsql(this.Configuration.GetConnectionString(nameof(ApplicationDbContext)));
			}
			else if (string.IsNullOrWhiteSpace(provider))
			{
				options.UseSqlServer(this.Configuration.GetConnectionString(nameof(ApplicationDbContext)));
			}
			else
			{
				throw new Exception("Unknown database provider supplied. Valid options are MSSQL and POSTGRESQL.");
			}

            return options.Options;
        }

        public virtual void MigrateDatabase(ApplicationDbContext context, ILogger<Startup> logger)
        {
			Policy policy = Policy
			  .Handle<Exception>()
			  .WaitAndRetry(
				   40,
				   retryAttempt => TimeSpan.FromSeconds(3),
				   (exception, timeSpan, retryCount, pollyContext) =>
				   {
					   logger.LogInformation($"Retrying database connection RetryCount={retryCount}. Error={exception.Message}.");
				   });

			policy.Execute(() =>
		    {
				if (this.Configuration.GetValue<bool>("MigrateDatabase"))
				{
			        context.Database.Migrate();
				}
			});
        }

        public virtual void SetupLogging(IServiceCollection services)
        {
             services.AddLogging(loggingBuilder => loggingBuilder
				.AddConsole()
				.AddDebug()
				.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
				.AddFilter("System", LogLevel.Information) 
				.AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Debug) 
				.AddConfiguration(this.Configuration.GetSection("Logging"))); 
        }

        public virtual void SetupAuthentication(IServiceCollection services)
        {
			byte[] key = Encoding.UTF8.GetBytes(this.Configuration["JwtSettings:SigningKey"]);
			if (key.Length <= 16)
			{
				throw new Exception("JWT key mut be longer than 16 characters");
			}

			services.AddIdentity<AuthUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.Configure<IdentityOptions>(options =>
			{
				// Password settings.
				options.Password.RequiredLength = 8;

				// options.Password.RequireDigit = true;
				// options.Password.RequireLowercase = true;
				// options.Password.RequireNonAlphanumeric = true;
				// options.Password.RequireUppercase = true;
				// options.Password.RequiredUniqueChars = 1;

				// Lockout settings.
				// options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				// options.Lockout.MaxFailedAccessAttempts = 5;
				// options.Lockout.AllowedForNewUsers = true;
				// options.SignIn.RequireConfirmedEmail = true;

				// User settings.
				options.User.AllowedUserNameCharacters =
				"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				options.User.RequireUniqueEmail = true;
			});

            services.AddAuthentication(cfg =>
			{
				cfg.DefaultScheme = IdentityConstants.ApplicationScheme;
				cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
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
                    ValidAudience = this.Configuration["JwtSettings:Audience"],
                    ValidIssuer = this.Configuration["JwtSettings:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
        }

		/// <summary>
		/// Set up authorization for the API
		/// </summary>
		/// <param name="services"></param>
		public virtual void SetupAuthorization(IServiceCollection services)
		{
			services.AddAuthorization(options =>
			{
				// set up your policies here
				// this can be modified to require claims or roles
				// options.AddPolicy("RequireAuthenticatedUser", policy =>
				// policy.RequireAuthenticatedUser());
			});
		}

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
           services.Configure<ApiSettings>(this.Configuration);

		   services.AddHealthChecks();

		   // enable CORS for all requests
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
                 var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
							.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                            .Build();

				 // add a policy requiring a an authenticated user to hit any controller
                 config.Filters.Add(new AuthorizeFilter(policy));

				 // add a total request time item to the response header collection
                 config.Filters.Add(new BenchmarkAttribute());

				 // reject requests with a null model
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
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };
                o.AddSecurityRequirement(security);
                o.AddSecurityDefinition("Bearer", new ApiKeyScheme() { In = "header", Description = "Please insert JWT prefixed with Bearer", Name = "Authorization", Type = "apiKey" });
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

            // register the mediator and register all handlers in the services assembly
			builder.AddMediatR(typeof(AbstractService).Assembly);

			// register HttpContextAccessor so we can access HttpContext outside of controllers
			builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

			// register UserStore so identity works
			builder.RegisterType<UserStore<AuthUser>>().As<IUserStore<AuthUser>>();

			// register EmailSender so we can send auth emails
			builder.RegisterType<EmailService>().As<IEmailService>();

			// register JwtService so we can create bearer tokens
			builder.RegisterType<JwtService>().As<IJwtService>();
			
			// register GuidService so we can mock Guid.NewGuid
			builder.RegisterType<GuidService>().As<IGuidService>();

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
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new ExceptionMiddleWare(env, loggerFactory).Invoke
            });

            this.MigrateDatabase(context, loggerFactory.CreateLogger<Startup>());

            app.UseAuthentication();

            app.UseSwagger();
				
			app.UseHealthChecks("/api/health");

            app.UseSwaggerUI(c =>
            {
                // remove .. from this line to make the swagger endpoint work from a console app
                // we have this to make it work in IIS with a virtual directory
                // c.SwaggerEndpoint("../swagger/v1/swagger.json", "Tests");
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Tests");
            });

            app.UseCors("AllowAll");

            app.UseMvc();

			string appDirectory = Path.Combine(env.ContentRootPath, "app");

		    if (Directory.Exists(appDirectory))
			{
			    PhysicalFileProvider fileProvider = new PhysicalFileProvider(appDirectory);
				DefaultFilesOptions defoptions = new DefaultFilesOptions();
				defoptions.DefaultFileNames.Clear();
				defoptions.FileProvider = fileProvider;
				defoptions.DefaultFileNames.Add("index.html");
				
				app.UseDefaultFiles(defoptions);
				
				app.UseStaticFiles(new StaticFileOptions
				{
					FileProvider = new PhysicalFileProvider(appDirectory),
					RequestPath = string.Empty
				});
			}

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
                Title = "Tests API " + description.ApiVersion,
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

    public static class ExceptionMiddleWareExtensions
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