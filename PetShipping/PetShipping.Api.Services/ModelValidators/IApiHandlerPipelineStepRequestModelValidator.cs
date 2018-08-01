using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IApiHandlerPipelineStepRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiHandlerPipelineStepRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerPipelineStepRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e6a88e1872b4278ad608201b1b9380a3</Hash>
</Codenesium>*/