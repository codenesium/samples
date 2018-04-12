using Microsoft.AspNetCore.Mvc.Filters;
namespace FermataFishNS.Api.Service
{
	public class StateFilter: ActionFilterAttribute
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
    <Hash>8ac9bf4c9b1eea818d14d5518f2c533b</Hash>
</Codenesium>*/