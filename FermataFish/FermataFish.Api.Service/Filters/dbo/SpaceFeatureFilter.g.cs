using Microsoft.AspNetCore.Mvc.Filters;
namespace FermataFishNS.Api.Service
{
	public class SpaceFeatureFilter: ActionFilterAttribute
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
    <Hash>a491d3f5ed33e92a9136a1855597a31f</Hash>
</Codenesium>*/