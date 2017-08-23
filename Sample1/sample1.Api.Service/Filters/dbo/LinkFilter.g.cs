using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
namespace sample1NS.Api.Service
{
	public class LinkFilter: ActionFilterAttribute
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
    <Hash>5571eea555325f1131271101c9cb15f6</Hash>
</Codenesium>*/