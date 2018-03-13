using Microsoft.AspNetCore.Mvc.Filters;
namespace FileServiceNS.Api.Service
{
	public class BucketFilter: ActionFilterAttribute
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
    <Hash>c7c4ba17324a826ebfe5735cfc86be23</Hash>
</Codenesium>*/