using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiHandlerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiHandlerRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e18b657f4d1a5b406689291561a7efce</Hash>
</Codenesium>*/