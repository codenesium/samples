using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiPipelineStepModelMapper
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
    <Hash>76345ab0d5dbda3ca7c20ef18cc4b378</Hash>
</Codenesium>*/