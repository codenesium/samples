using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiPipelineStepStepRequirementModelMapper
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
    <Hash>6399c5ccd3edd60cbd28759a3a773f97</Hash>
</Codenesium>*/