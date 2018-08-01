using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiHandlerPipelineStepModelMapper
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
    <Hash>bb61b9e83b629761ecff6c4ee6568fe2</Hash>
</Codenesium>*/