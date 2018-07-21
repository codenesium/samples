using Codenesium.DataConversionExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace Codenesium.Foundation.CommonMVC
{
    /// <summary>
    /// Simple controller that tests that you're able to connect to the database.
    /// </summary>
    [Route("api/apihealth")]
    public class ApiHealthController : AbstractApiController
    {
        private DbContext context;

        public ApiHealthController(
                       ApiSettings settings,
                       ILogger<ApiHealthController> logger,
                       ITransactionCoordinator transactionCoordinator,
                       DbContext context
                       )
                       : base(settings, logger, transactionCoordinator)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("")]
        [ReadOnly]
        [ProducesResponseType(typeof(string), 200)]
        public async virtual Task<IActionResult> Health()
        {
            await this.context.Database.OpenConnectionAsync();
            await this.context.Database.ExecuteSqlCommandAsync(new RawSqlString("SELECT GETDATE()"));
            this.context.Database.CloseConnection();
            return this.Ok("Api is healthy!");
        }
    }

    /// <summary>
    /// ITransactionCoordinator is an interface that is injecteded into controllers and allows
    /// us to handle transactions on requests and enable and disable change tracking for entity framework
    /// </summary>
    public interface ITransactionCoordinator
    {
        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

        void EnableChangeTracking();

        void DisableChangeTracking();
    }

	/// <summary>
    /// EntityFrameworkTransactionCoordinator is the transaction coordinator when using
	///  Entity Framework
    /// </summary>
    public class EntityFrameworkTransactionCoordinator : ITransactionCoordinator
    {
        private DbContext context;

        public EntityFrameworkTransactionCoordinator(DbContext context)
        {
            this.context = context;
        }

        public void BeginTransaction()
        {
            this.context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (this.context.Database.CurrentTransaction != null)
            {
                this.context.Database.CommitTransaction();
            }
        }

        public void DisableChangeTracking()
        {
            this.context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public void EnableChangeTracking()
        {
            this.context.ChangeTracker.AutoDetectChangesEnabled = true;
        }

        public void RollbackTransaction()
        {
            if (this.context.Database.CurrentTransaction != null)
            {
                this.context.Database.RollbackTransaction();
            }
        }
    }

    /// <summary>
    /// This is the base controller for any controller that needs transaction support.
    /// We use an action filter to start and commit transactions using the TransactionCooordinator.
    /// </summary>
    public abstract class AbstractApiController : Controller
    {
        public ITransactionCoordinator TransactionCooordinator { get; private set; }

        protected ILogger Logger { get; private set;  }

		protected ApiSettings Settings { get; private set;  }

        public AbstractApiController(
	        ApiSettings settings,
            ILogger logger,
            ITransactionCoordinator transactionCooordinator
            )
        {
            this.Logger = logger;
			this.Settings = settings;
            this.TransactionCooordinator = transactionCooordinator;
        }
    }

    /// <summary>
    /// The purpose of this filter is to throw an error when a client passes a null model to a controller
    /// from http://stackoverflow.com/questions/14517151/how-to-ensure-asp-net-web-api-controllers-parameter-is-not-null
    /// and https://stackoverflow.com/questions/28835869/capture-exception-during-request-deserialization-in-webapi-c-sharp
    /// </summary>
    public class NullModelValidaterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ActionArguments.Any(v => v.Value == null))
            {
                actionContext.Result = new BadRequestObjectResult("model was null");
            }
            else
            {
                if (actionContext.ModelState.IsValid)
                {
                    base.OnActionExecuting(actionContext);
                }
                else
                {
                    List<Exception> exceptions = new List<Exception>();

                    foreach (var state in actionContext.ModelState)
                    {
                        if (state.Value.Errors.Count != 0)
                        {
                            exceptions.AddRange(state.Value.Errors.Select(error => error.Exception));
                        }
                    }

                    if (exceptions.Count > 0)
                    {
                        actionContext.Result = new BadRequestObjectResult(exceptions);
                    }
                }
            }
        }
	}

    /// <summary>
    /// This attribute can be added to disable entity framework change tracking for read only scenarios. This can
	/// drastically improve performance.
    /// </summary>
    public class ReadOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
			if (!(actionContext.Controller is AbstractApiController))
			{
				throw new Exception("ReadOnlyFilter can only be applied to controllers that inherit from AbstractApiController");
			}

            AbstractApiController controller = (AbstractApiController)actionContext.Controller;

            controller.TransactionCooordinator.DisableChangeTracking();
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }

	/// <summary>
    /// This attribute enabled transaction support on a request by hooking in to the request pipeline
	/// and starting a transaction when a request begins and committing or rolling back the transaction if 
	/// there is an exception during the request.
    /// </summary>
    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
			if (!(actionContext.Controller is AbstractApiController))
			{
				throw new Exception("UnitOfWorkActionFilter can only be applied to controllers that inherit from AbstractApiController");
			}

			AbstractApiController controller = (AbstractApiController)actionContext.Controller;

			controller.TransactionCooordinator.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            AbstractApiController controller = (AbstractApiController)actionExecutedContext.Controller;

            if (actionExecutedContext.Exception == null)
            {
                try
                {
                    controller.TransactionCooordinator.CommitTransaction();
                }
			    catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                try
                {
                    controller.TransactionCooordinator.RollbackTransaction();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }

	/// <summary>
    /// This filter logs the time it takes to execute a request and returns the execution time
	/// to the client in the header x-time-elapsed
    /// 
    /// </summary>
	public class BenchmarkAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext actionContext, ActionExecutionDelegate next)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            await next();
            stopwatch.Stop();
            actionContext.HttpContext.Response.Headers.Add("x-time-elapsed", stopwatch.Elapsed.ToString());
        }
    }
  
    public class ResponseAttribute : ActionFilterAttribute
    {
		public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is OkObjectResult)
            {
                OkObjectResult result = context.Result as OkObjectResult;
                if (result.Value is ApiResponse)
                {
                    var response = result.Value as ApiResponse;
                    response.DisableSerializationOfEmptyFields();
                    context.Result = new OkObjectResult(response);
                }
            }

            base.OnActionExecuted(context);
        }
    }

    /// <summary>
    /// This filter helps api versioning work with swagger
    /// https://github.com/Microsoft/aspnet-api-versioning/wiki/Swashbuckle-Integration
    /// </summary>
    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                return;
            }

            foreach (var parameter in operation.Parameters.OfType<NonBodyParameter>())
            {
                var description = context.ApiDescription
                                         .ParameterDescriptions
                                         .First(p => p.Name == parameter.Name);
                var routeInfo = description.RouteInfo;

                if (parameter.Description == null)
                {
                    parameter.Description = description.ModelMetadata?.Description;
                }

                if (routeInfo == null)
                {
                    continue;
                }

                if (parameter.Default == null)
                {
                    parameter.Default = routeInfo.DefaultValue;
                }

                parameter.Required |= !routeInfo.IsOptional;
            }
        }
    }

	public class ApiSettings
    {
        public virtual string ExternalBaseUrl { get; set; }

        public virtual bool MigrateDatabase { get; set; }

        public virtual bool SecurityEnabled { get; set; }

        public virtual JwtSettings JwtSettings { get; set; }
    }

    public class JwtSettings
    {
        public virtual string SigningKey { get; set; }

        public virtual string Issuer { get; set; }

        public virtual string Audience { get; set; }
    }

    public class SearchQuery
    {
        public int Limit { get; private set; } = 0;

        public int Offset { get; private set; } = 0;

        public string WhereClause { get; private set; } = string.Empty;

        public string Error { get; private set; } = string.Empty;

        public SearchQuery()
        {
        }

		public void Process(int maxLimit, int defaultLimit, int? limit, int? offset, Dictionary<string, Microsoft.Extensions.Primitives.StringValues> queryParameters)
        {
            this.Offset = offset ?? 0;
            this.Limit = limit ?? maxLimit;

            if (this.Limit > maxLimit)
            {
                this.Error = $"Limit of {this.Limit} exceeds maximum request size of {maxLimit} records";
                return;
            }

            foreach (var parameter in queryParameters)
            {
                if (parameter.Key.ToUpper() == "OFFSET" || parameter.Key.ToUpper() == "LIMIT")
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(this.WhereClause))
                {
                    this.WhereClause += " && ";
                }

                if (parameter.Value.ToString().ToNullableInt() != null)
                {
                    this.WhereClause += $"{parameter.Key}.Equals({parameter.Value})";
                }
                else if (parameter.Value.ToString().ToNullableGuid() != null)
                {
                    this.WhereClause += $"{parameter.Key}.Equals(Guid(\"{parameter.Value}\"))";
                }
                else
                {
                    this.WhereClause += $"{parameter.Key}.Equals(\"{parameter.Value}\")";
                }
            }
			
            if (string.IsNullOrWhiteSpace(this.WhereClause))
            {
                this.WhereClause = "1=1";
            }
        }
    }
}