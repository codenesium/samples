using System;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net.Http;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public class PersonFilter: ActionFilterAttribute
	{
		IPersonModelValidator validator { get; set; }

		public PersonFilter(IPersonModelValidator validator)
		{
			this.validator = validator;
		}

		public override void OnActionExecuted(ActionExecutedContext context)
		{
			if (context.Result is OkObjectResult)
			{
				OkObjectResult result = context.Result as OkObjectResult;
				if (result.Value is ApiResponse)
				{
					var response = result.Value as ApiResponse;
					response.DisableSerializationOfEmptyFields();
					context.Result = new OkObjectResult(response);
				}
			}
			base.OnActionExecuted(context);
		}

		public override void OnActionExecuting(ActionExecutingContext actionContext)
		{
			if (actionContext.ActionArguments.Any(kv => kv.Value == null))
			{
				actionContext.Result = new BadRequestObjectResult("Null model is invalid");

				return;
			}

			var items = actionContext.ActionArguments.Values.OfType<PersonModel>().ToList();

			if (items.Any())
			{
				if (actionContext.HttpContext.Request.Method == HttpMethod.Post.ToString())
				{
					this.validator.CreateMode();
				}
				else if (actionContext.HttpContext.Request.Method == HttpMethod.Put.ToString())
				{
					this.validator.UpdateMode();
				}
				else if (actionContext.HttpContext.Request.Method == HttpMethod.Delete.ToString())
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
    <Hash>fb86bff8afb2b61b2300b86c042e04dd</Hash>
</Codenesium>*/