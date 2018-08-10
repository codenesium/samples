using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiHandlerPipelineStepRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiHandlerPipelineStepRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerPipelineStepRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>825766f8a4f0c52faf4484b331eff1cd</Hash>
</Codenesium>*/