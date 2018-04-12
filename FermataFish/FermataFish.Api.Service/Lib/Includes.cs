using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codenesium.Foundation.CommonMVC
{
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

        protected ILogger logger { get; set; }

        public AbstractApiController(
            ILogger logger,
            ITransactionCoordinator transactionCooordinator
            )
        {
            this.logger = logger;
            this.TransactionCooordinator = transactionCooordinator;
        }
    }



    /// <summary>
    /// The purpose of this filter is to throw an error when a client passes a null model to a controller
    /// from http://stackoverflow.com/questions/14517151/how-to-ensure-asp-net-web-api-controllers-parameter-is-not-null
    /// </summary>
    public class ModelValidateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ActionArguments.Any(v => v.Value == null))
            {
                actionContext.Result = new BadRequestObjectResult("model was null");
            }
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }

    /// <summary>
    /// This attribute can be added to disable entity framework change tracking for read only scenarios. This can
	/// drastically improve performance.
    /// </summary>
    public class ReadOnlyFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
			if(!(actionContext.Controller is AbstractApiController))
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
    public class UnitOfWorkActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
			if(!(actionContext.Controller is AbstractApiController))
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
  
    public class SearchQuery
    {
        public int Limit { get; private set; } = 0;

        public int Offset { get; private set; } = 0;

        public string WhereClause { get; private set; } = string.Empty;

        public string Error { get; private set; } = string.Empty;

        public SearchQuery()
        {
        }

        public void Process(int searchRecordLimit, int searchRecordDefault, Dictionary<string, Microsoft.Extensions.Primitives.StringValues> queryParameters)
        {
            this.Limit = searchRecordLimit;

            if (!queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "OFFSET").Equals(default(KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>)))
            {
                this.Offset = queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "OFFSET").Value.ToInt();
            }

            if (!queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "LIMIT").Equals(default(KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>)))
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