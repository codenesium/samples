using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiPipelineStepDestinationModelMapper
	{
		ApiPipelineStepDestinationResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStepDestinationRequestModel request);

		ApiPipelineStepDestinationRequestModel MapResponseToRequest(
			ApiPipelineStepDestinationResponseModel response);

		JsonPatchDocument<ApiPipelineStepDestinationRequestModel> CreatePatch(ApiPipelineStepDestinationRequestModel model);
	}
}

/*<Codenesium>
    <Hash>1aab929d31a0e29d5f50c50f30d8568b</Hash>
</Codenesium>*/