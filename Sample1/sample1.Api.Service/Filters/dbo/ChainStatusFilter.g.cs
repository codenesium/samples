using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
namespace sample1NS.Api.Service
{
	public class ChainStatusFilter: ActionFilterAttribute
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
    <Hash>f27bfb867732626ef6f8814f0ce9dc30</Hash>
</Codenesium>*/