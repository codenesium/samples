using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiHandlerPipelineStepServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiHandlerPipelineStepServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerPipelineStepServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>93386b2e5187087df4e7639615eeca2c</Hash>
</Codenesium>*/