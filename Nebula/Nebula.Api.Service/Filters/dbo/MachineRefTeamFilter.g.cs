using Microsoft.AspNetCore.Mvc.Filters;
namespace NebulaNS.Api.Service
{
	public class MachineRefTeamFilter: ActionFilterAttribute
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
    <Hash>cbb5f3e5fd512e1f003475f4db4a9bba</Hash>
</Codenesium>*/