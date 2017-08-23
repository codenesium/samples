using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
namespace sample1NS.Api.Service
{
	public class ChainFilter: ActionFilterAttribute
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
    <Hash>76bb67a2c601ab40cda10940d679c60e</Hash>
</Codenesium>*/