using Microsoft.AspNetCore.Mvc.Filters;
namespace FermataFishNS.Api.Service
{
	public class AdminFilter: ActionFilterAttribute
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
    <Hash>e7e64b2625de314d4bd0538f4f79079a</Hash>
</Codenesium>*/