using Microsoft.AspNetCore.Mvc.Filters;
namespace ESPIOTNS.Api.Service
{
	public class DeviceFilter: ActionFilterAttribute
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
    <Hash>07ead03b8e79d8aed5ad78aed3435892</Hash>
</Codenesium>*/