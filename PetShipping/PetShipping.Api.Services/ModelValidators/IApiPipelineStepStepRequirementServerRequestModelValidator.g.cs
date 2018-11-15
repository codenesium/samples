using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepStepRequirementServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStepRequirementServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStepRequirementServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9e152001ed58595e0fa4f0e55b08b14f</Hash>
</Codenesium>*/