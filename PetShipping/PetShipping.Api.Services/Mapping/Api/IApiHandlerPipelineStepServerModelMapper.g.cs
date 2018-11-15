using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiHandlerPipelineStepServerModelMapper
	{
		ApiHandlerPipelineStepServerResponseModel MapServerRequestToResponse(
			int id,
			ApiHandlerPipelineStepServerRequestModel request);

		ApiHandlerPipelineStepServerRequestModel MapServerResponseToRequest(
			ApiHandlerPipelineStepServerResponseModel response);

		ApiHandlerPipelineStepClientRequestModel MapServerResponseToClientRequest(
			ApiHandlerPipelineStepServerResponseModel response);

		JsonPatchDocument<ApiHandlerPipelineStepServerRequestModel> CreatePatch(ApiHandlerPipelineStepServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a29545503cc977aef60ef261d6d98b7b</Hash>
</Codenesium>*/