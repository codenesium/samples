using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStatusServerModelMapper
	{
		ApiPipelineStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStatusServerRequestModel request);

		ApiPipelineStatusServerRequestModel MapServerResponseToRequest(
			ApiPipelineStatusServerResponseModel response);

		ApiPipelineStatusClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStatusServerResponseModel response);

		JsonPatchDocument<ApiPipelineStatusServerRequestModel> CreatePatch(ApiPipelineStatusServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>be80947722aaaa9f231eb2649471e116</Hash>
</Codenesium>*/