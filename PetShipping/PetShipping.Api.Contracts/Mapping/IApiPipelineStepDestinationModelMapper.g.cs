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
    <Hash>99ac7db879e6518ec5f981288e6a12f5</Hash>
</Codenesium>*/