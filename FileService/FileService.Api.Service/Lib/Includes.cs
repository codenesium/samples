using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Validation;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Mvc;
using NLog;

namespace Codenesium.Foundation.CommonMVC
{
   /// <summary>
    /// This is the base controller for any controller that needs transaction support.
    /// We use an action filter to start and commit transactions using the Conttext.
    /// </summary>
    public abstract class AbstractEntityFrameworkApiController : ApiController
    {
        public System.Data.Entity.DbContext Context { get; private set; }
        protected Autofac.Extras.NLog.ILogger _logger { get; set; }

        public AbstractEntityFrameworkApiController(
            Autofac.Extras.NLog.ILogger logger,
            DbContext context

            )
        {
            this._logger = logger;
            this.Context = context;
            this.Context.Configuration.LazyLoadingEnabled = false;
        }
    }



    /// <summary>
    /// The purpose of this filter is to throw an error when a client passes a null model to a controller
    /// from http://stackoverflow.com/questions/14517151/how-to-ensure-asp-net-web-api-controllers-parameter-is-not-null
    /// </summary>
    public class ModelValidateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments.Any(v => v.Value == null))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }

    /// <summary>
    /// This attribute can be added to disable entity framework change tracking
    /// </summary>
    public class ReadOnlyFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            AbstractEntityFrameworkApiController controller = (AbstractEntityFrameworkApiController)actionContext.ControllerContext.Controller;
            controller.Context.Configuration.AutoDetectChangesEnabled = false; //disable change tracking in context
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }

    public class UnitOfWorkActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            AbstractEntityFrameworkApiController controller = (AbstractEntityFrameworkApiController)actionContext.ControllerContext.Controller;
            controller.Context.Database.BeginTransaction();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            AbstractEntityFrameworkApiController controller = (AbstractEntityFrameworkApiController)actionExecutedContext.ActionContext.ControllerContext.Controller;

            if (actionExecutedContext.Exception == null)
            {
                try
                {
                    if (controller.Context.Database.CurrentTransaction != null)
                    {
                        controller.Context.Database.CurrentTransaction.Commit();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    controller.Context.Dispose();
                }
            }
            else
            {
                try
                {
                    if (controller.Context.Database.CurrentTransaction != null)
                    {
                        controller.Context.Database.CurrentTransaction.Rollback();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    controller.Context.Dispose();
                }
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }

    /// <summary>
    /// From https://json.codes/blog/integrating-fluent-validation-with-aspnet-web-api/
    /// Provides a validation module for classes that end with "Validator"
    /// </summary>
    public class AutofacValidatorFactory : ValidatorFactoryBase
    {
        private readonly IComponentContext _context;

        public AutofacValidatorFactory(IComponentContext context)
        {
            _context = context;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            object instance;
            if (_context.TryResolve(validatorType, out instance))
            {
                var validator = instance as IValidator;
                return validator;
            }

            return null;
        }
    }

    public class ValidationModule : Autofac.Module
    {
        private List<Type> _types = new List<Type>();

        public ValidationModule(List<Type> types)
        {
            this._types = types;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterTypes(this._types.ToArray())
           .Where(t => t.Name.EndsWith("Validator"))
           .AsImplementedInterfaces()
           .AsSelf()
           .PropertiesAutowired();

            builder.RegisterType<FluentValidationModelValidatorProvider>().As<System.Web.Mvc.ModelValidatorProvider>();
            builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>().SingleInstance();

            base.Load(builder);
        }
    }

    /// <summary>
    /// The purpose of this contrller is to allow a redirect in
    /// a WepAPI project to the swagger page.
    /// http://stackoverflow.com/questions/33891721/asp-net-webapi-default-landing-page
    /// </summary>
    public class SwaggerController : System.Web.Mvc.Controller
    {
        // GET: Browser
        public System.Web.Mvc.ActionResult Index()
        {
            return Redirect("swagger");
        }
    }

	public class SearchQuery
    {
        public int Limit { get; private set; } = 0;
        public int Offset { get; private set; } = 0;
        public string WhereClause { get; private set; } = "";
        public string Error { get; private set; } = "";

        public SearchQuery()
        {       
        }

        public void Process(int searchRecordLimit, int searchRecordDefault, IEnumerable<KeyValuePair<string, string>> queryParameters)
        {
            this.Limit = searchRecordLimit;

            if (!queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "OFFSET").Equals(default(KeyValuePair<string, string>)))
            {
                this.Offset = queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "OFFSET").Value.ToInt();
            }

            if (!queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "LIMIT").Equals(default(KeyValuePair<string, string>)))
            {
                this.Limit = queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "LIMIT").Value.ToInt();
            }

            if (this.Limit > searchRecordLimit)
            {
                this.Error = $"Limit of {this.Limit} exceeds maximum request size of {searchRecordLimit} records";
                return;
            }

            foreach (var parameter in queryParameters)
            {
                if (parameter.Key.ToUpper() == "OFFSET" || parameter.Key.ToUpper() == "LIMIT")
                {
                    continue;
                }

                if (!String.IsNullOrEmpty(this.WhereClause))
                {
                    this.WhereClause += " && ";
                }

                if (parameter.Value.ToNullableInt() != null)
                {
                    this.WhereClause += $"{parameter.Key}.Equals({parameter.Value})";
                }
                else if (parameter.Value.ToNullableGuid() != null)
                {
                    this.WhereClause += $"{parameter.Key}.Equals(Guid(\"{parameter.Value}\"))";
                }
                else
                {
                    this.WhereClause += $"{parameter.Key}.Equals(\"{parameter.Value}\")";
                }
            }
            if (String.IsNullOrWhiteSpace(this.WhereClause))
            {
                this.WhereClause = "1=1";
            }
        }
    }

	
    /// <summary>
    /// DelegatingHandler that is inserted into the pipeline so that
    /// we can log all requests and reaponses when trace logging is enabled
    /// </summary>
    public class LoggingHandler : DelegatingHandler
    {
        private Logger _logger { get; set; }

        public LoggingHandler(Logger logger)
        {
            this._logger = logger;
        }
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (this._logger.IsTraceEnabled)
            {
                // log request body
                string method = request.Method.Method;
                string uri = request.RequestUri.OriginalString;
                string requestBody = await request.Content.ReadAsStringAsync();
                this._logger.Trace($"{uri} {method} {requestBody}");
            }
            

            // send the request doen the pipeline
            var result = await base.SendAsync(request, cancellationToken);

            if (this._logger.IsTraceEnabled)
            {
	     		var responseBody = String.Empty;
                if (result.Content != null)
                {
                    responseBody = await result.Content.ReadAsStringAsync();
				}
                this._logger.Trace($"{result.StatusCode} {responseBody}");
            }
            return result;
        }
    }
}