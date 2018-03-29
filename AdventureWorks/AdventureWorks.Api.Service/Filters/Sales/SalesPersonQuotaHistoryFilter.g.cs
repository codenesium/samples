using Microsoft.AspNetCore.Mvc.Filters;
namespace AdventureWorksNS.Api.Service
{
	public class SalesPersonQuotaHistoryFilter: ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext actionContext)
		{}

		public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
		{
			base.OnActionExecuted(actionExecutedContext);
		}
	}
}

/*<Codenesium>
    <Hash>bfa4009eb749624f1da315c59e3fd6d0</Hash>
</Codenesium>*/