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
    <Hash>3c07b98a8989b112900c2d9aa8c68658</Hash>
</Codenesium>*/