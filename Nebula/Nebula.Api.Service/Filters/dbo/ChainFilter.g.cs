using Microsoft.AspNetCore.Mvc.Filters;
namespace NebulaNS.Api.Service
{
	public class ChainFilter: ActionFilterAttribute
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
    <Hash>bbcdfbbcf4a7d9521444aa314de6c6f9</Hash>
</Codenesium>*/