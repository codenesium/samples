using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiPipelineStepModelMapper
	{
		ApiPipelineStepResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStepRequestModel request);

		ApiPipelineStepRequestModel MapResponseToRequest(
			ApiPipelineStepResponseModel response);

		JsonPatchDocument<ApiPipelineStepRequestModel> CreatePatch(ApiPipelineStepRequestModel model);
	}
}

/*<Codenesium>
    <Hash>39421e16f75bd4be09d9b9b3f3a10512</Hash>
</Codenesium>*/