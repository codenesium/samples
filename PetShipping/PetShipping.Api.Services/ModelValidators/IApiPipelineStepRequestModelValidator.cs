using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IApiPipelineStepRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a059aa8ff295ad70b0a76e6c8832ca01</Hash>
</Codenesium>*/