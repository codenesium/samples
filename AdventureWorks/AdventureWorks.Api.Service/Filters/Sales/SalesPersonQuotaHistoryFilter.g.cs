using System;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public class SalesPersonQuotaHistoryFilter: ActionFilterAttribute
	{
		ISalesPersonQuotaHistoryModelValidator validator { get; set; }

		public SalesPersonQuotaHistoryFilter(ISalesPersonQuotaHistoryModelValidator validator)
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

			var items = actionContext.ActionArguments.Values.OfType<SalesPersonQuotaHistoryModel>().ToList();

			if (items.Any())
			{
				if(actionContext.HttpContext.Request.Method == "POST")
				{
					this.validator.CreateMode();
				}
				else if (actionContext.HttpContext.Request.Method == "PUT")
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

				Action<ValidationResult> addError = (result) =>
				{
					foreach (var error in result.Errors)
					{
						actionContext.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
					}
				};

				bool validationFailure = false;
				items.ForEach(x =>
				{
					ValidationResult result = this.validator.Validate(x);
					if (!result.IsValid)
					{
					        validationFailure = true;
					        addError(result);
					}
				});

				if (validationFailure)
				{
					actionContext.Result = new BadRequestObjectResult(actionContext.ModelState);
				}
			}
		}
	}
}

/*<Codenesium>
    <Hash>797a6cf61ffbaf9419c8bce0d75fe8a6</Hash>
</Codenesium>*/