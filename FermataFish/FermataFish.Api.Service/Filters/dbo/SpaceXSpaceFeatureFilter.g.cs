using Microsoft.AspNetCore.Mvc.Filters;
namespace FermataFishNS.Api.Service
{
	public class SpaceXSpaceFeatureFilter: ActionFilterAttribute
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
    <Hash>adb1b56dc5352b2c2dcd5c93ba444d18</Hash>
</Codenesium>*/