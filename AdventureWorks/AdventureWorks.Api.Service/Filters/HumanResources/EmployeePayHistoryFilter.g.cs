using Microsoft.AspNetCore.Mvc.Filters;
namespace AdventureWorksNS.Api.Service
{
	public class EmployeePayHistoryFilter: ActionFilterAttribute
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
    <Hash>4001536f0dba6543fc6b2c904ea922ba</Hash>
</Codenesium>*/