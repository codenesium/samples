using Microsoft.AspNetCore.Mvc.Filters;
namespace FileServiceNS.Api.Service
{
	public class FileFilter: ActionFilterAttribute
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
    <Hash>5a86c4491f0790cef2e34bc933c36437</Hash>
</Codenesium>*/