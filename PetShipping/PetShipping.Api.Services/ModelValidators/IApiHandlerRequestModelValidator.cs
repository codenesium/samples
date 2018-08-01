using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IApiHandlerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiHandlerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0375d0ac70df772861974a90a836b1db</Hash>
</Codenesium>*/