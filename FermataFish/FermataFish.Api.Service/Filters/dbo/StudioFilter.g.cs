using Microsoft.AspNetCore.Mvc.Filters;
namespace FermataFishNS.Api.Service
{
	public class StudioFilter: ActionFilterAttribute
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
    <Hash>6299b541be8aaed4715115d8fdacfa97</Hash>
</Codenesium>*/