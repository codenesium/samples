using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepStepRequirementRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStepRequirementRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStepRequirementRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>39d8b11d83cc7acef97df333308e6299</Hash>
</Codenesium>*/