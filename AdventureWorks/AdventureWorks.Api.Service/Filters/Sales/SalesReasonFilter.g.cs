using Microsoft.AspNetCore.Mvc.Filters;
namespace AdventureWorksNS.Api.Service
{
	public class SalesReasonFilter: ActionFilterAttribute
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
    <Hash>6fbdd988689ce46b8f6cac5b53ace78e</Hash>
</Codenesium>*/