using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiPipelineStepStepRequirementModelMapper
	{
		ApiPipelineStepStepRequirementResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStepStepRequirementRequestModel request);

		ApiPipelineStepStepRequirementRequestModel MapResponseToRequest(
			ApiPipelineStepStepRequirementResponseModel response);

		JsonPatchDocument<ApiPipelineStepStepRequirementRequestModel> CreatePatch(ApiPipelineStepStepRequirementRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d07b329e6a136e1df58ca439e3a4f12f</Hash>
</Codenesium>*/