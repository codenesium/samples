using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IApiPipelineStepStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ae3c0483a60720cffe14946a9f91d6da</Hash>
</Codenesium>*/