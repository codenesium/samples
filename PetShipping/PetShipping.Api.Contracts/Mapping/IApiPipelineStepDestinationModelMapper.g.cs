using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiPipelineStepDestinationModelMapper
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
    <Hash>fd8a09643d369667f923359feee50407</Hash>
</Codenesium>*/