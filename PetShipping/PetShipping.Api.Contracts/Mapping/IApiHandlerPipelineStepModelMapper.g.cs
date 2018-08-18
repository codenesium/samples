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
    <Hash>0bd4bbc303bac589babd8bef6ce283cc</Hash>
</Codenesium>*/