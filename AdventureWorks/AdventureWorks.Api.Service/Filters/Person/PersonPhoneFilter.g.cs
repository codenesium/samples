using Microsoft.AspNetCore.Mvc.Filters;
namespace AdventureWorksNS.Api.Service
{
	public class PersonPhoneFilter: ActionFilterAttribute
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
    <Hash>9b843ae499063997338789eeacf7ce9a</Hash>
</Codenesium>*/