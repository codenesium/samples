using Microsoft.AspNetCore.Mvc.Filters;
namespace AdventureWorksNS.Api.Service
{
	public class BusinessEntityFilter: ActionFilterAttribute
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
    <Hash>52858ce04ba88a930070b8824969b954</Hash>
</Codenesium>*/