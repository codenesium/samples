using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
namespace sample1NS.Api.Service
{
	public class LinkStatusFilter: ActionFilterAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
		{}

		public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
		{
			base.OnActionExecuted(actionExecutedContext);
		}
	}
}

/*<Codenesium>
    <Hash>8bca9cb6472dea9d1b85d9e49e8cd90c</Hash>
</Codenesium>*/