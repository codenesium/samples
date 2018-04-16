using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NebulaNS.Api.Contracts;
using System.Linq;

namespace NebulaNS.Api.Service
{
	public class ChainFilter : ActionFilterAttribute
	{
        IChainModelValidator validator { get; set; }

        public ChainFilter(IChainModelValidator validator)
        {
            this.validator = validator;
        }
        public override void OnActionExecuting(ActionExecutingContext actionContext)
		{


            if (actionContext.ActionArguments.Any(kv => kv.Value == null))
            {
                actionContext.Result = new BadRequestObjectResult("Null model is invalid");
                return;
            }

            var items = actionContext.ActionArguments.Values.OfType<ChainModel>().ToList();
            if (items.Any())
            {
                if(actionContext.HttpContext.Request.Method == "POST")
                {
                    this.validator.CreateMode();
                }
                else  if (actionContext.HttpContext.Request.Method == "PUT")
                {
                    this.validator.UpdateMode();
                }
                else if (actionContext.HttpContext.Request.Method == "DELETE")
                {
                    this.validator.DeleteMode();
                }
                else
                {
                    return;
                }
   
                var result = this.validator.Validate(items.First());
                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                    {
                        actionContext.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    actionContext.Result = new BadRequestObjectResult(actionContext.ModelState);
                }

            }
        }

		public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
		{
			base.OnActionExecuted(actionExecutedContext);
		}
	}
}

/*<Codenesium>
    <Hash>bbcdfbbcf4a7d9521444aa314de6c6f9</Hash>
</Codenesium>*/