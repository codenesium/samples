using Microsoft.AspNetCore.Mvc.Filters;
namespace NebulaNS.Api.Service
{
	public class ChainStatusFilter: ActionFilterAttribute
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
    <Hash>cfb2c2e72693a41a4e5d89151e9a4f2b</Hash>
</Codenesium>*/