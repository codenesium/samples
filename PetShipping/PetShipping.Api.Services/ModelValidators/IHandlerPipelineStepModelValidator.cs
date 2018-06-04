using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
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
    <Hash>80895280188ea2c0a8d5b9ce7223f037</Hash>
</Codenesium>*/