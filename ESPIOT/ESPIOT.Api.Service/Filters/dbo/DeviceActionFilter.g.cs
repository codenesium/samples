using Microsoft.AspNetCore.Mvc.Filters;
namespace ESPIOTNS.Api.Service
{
	public class DeviceActionFilter: ActionFilterAttribute
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
    <Hash>2770f3a576eb637744927586eb0a6b9f</Hash>
</Codenesium>*/