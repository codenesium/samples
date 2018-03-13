using Microsoft.AspNetCore.Mvc.Filters;
namespace FileServiceNS.Api.Service
{
	public class FileTypeFilter: ActionFilterAttribute
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
    <Hash>fc6bf8b4f2bf85f12ec404536b052bf5</Hash>
</Codenesium>*/