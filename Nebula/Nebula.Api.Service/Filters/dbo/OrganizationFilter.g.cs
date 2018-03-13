using Microsoft.AspNetCore.Mvc.Filters;
namespace NebulaNS.Api.Service
{
	public class OrganizationFilter: ActionFilterAttribute
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
    <Hash>32594e52c55d2d2ec8edd8d69996096c</Hash>
</Codenesium>*/