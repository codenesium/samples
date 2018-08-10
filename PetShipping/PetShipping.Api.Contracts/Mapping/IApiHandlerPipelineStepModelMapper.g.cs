using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiHandlerPipelineStepModelMapper
	{
		ApiHandlerPipelineStepResponseModel MapRequestToResponse(
			int id,
			ApiHandlerPipelineStepRequestModel request);

		ApiHandlerPipelineStepRequestModel MapResponseToRequest(
			ApiHandlerPipelineStepResponseModel response);

		JsonPatchDocument<ApiHandlerPipelineStepRequestModel> CreatePatch(ApiHandlerPipelineStepRequestModel model);
	}
}

/*<Codenesium>
    <Hash>1a48ba34ec7048cd4f0fc9cffadaf8b0</Hash>
</Codenesium>*/