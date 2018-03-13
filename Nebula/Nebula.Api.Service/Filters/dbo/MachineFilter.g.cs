using Microsoft.AspNetCore.Mvc.Filters;
namespace NebulaNS.Api.Service
{
	public class MachineFilter: ActionFilterAttribute
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
    <Hash>28b6cc59d6657dd76da686821803edce</Hash>
</Codenesium>*/