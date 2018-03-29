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
    /// This is the base controller for any controller that needs transaction support.
    /// We use an action filter to start and commit transactions using the Conttext.
    /// </summary>
    public abstract class AbstractEntityFrameworkApiController : Controller
    {
        public DbContext Context { get; private set; }
        protected ILogger _logger { get; set; }

        public AbstractEntityFrameworkApiController(
            ILogger logger,
            DbContext context

            )
        {
            this._logger = logger;
            this.Context = context;
            //this.Context.Database.Configuration.LazyLoadingEnabled = false not supported yet
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
    /// This attribute can be added to disable entity framework change tracking
    /// </summary>
    public class ReadOnlyFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            AbstractEntityFrameworkApiController controller = (AbstractEntityFrameworkApiController)actionContext.Controller;
            controller.Context.ChangeTracker.AutoDetectChangesEnabled = false; //disable change tracking in context
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }

    public class UnitOfWorkActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            AbstractEntityFrameworkApiController controller = (AbstractEntityFrameworkApiController)actionContext.Controller;
            controller.Context.Database.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            AbstractEntityFrameworkApiController controller = (AbstractEntityFrameworkApiController)actionExecutedContext.Controller;

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
  
    public class SearchQuery
    {
        public int Limit { get; private set; } = 0;
        public int Offset { get; private set; } = 0;
        public string WhereClause { get; private set; } = "";
        public string Error { get; private set; } = "";

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

                if (!String.IsNullOrEmpty(this.WhereClause))
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
            if (String.IsNullOrWhiteSpace(this.WhereClause))
            {
                this.WhereClause = "1=1";
            }
        }
    }
}