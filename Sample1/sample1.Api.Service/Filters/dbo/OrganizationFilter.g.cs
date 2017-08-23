using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
namespace sample1NS.Api.Service
{
	public class OrganizationFilter: ActionFilterAttribute
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
    <Hash>acd4a7bfdffbaf37979515c5b4eeb668</Hash>
</Codenesium>*/