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
    <Hash>3172c28f615f3f962b1743ea95043cef</Hash>
</Codenesium>*/