using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStatuServerModelMapper
	{
		ApiPipelineStatuServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStatuServerRequestModel request);

		ApiPipelineStatuServerRequestModel MapServerResponseToRequest(
			ApiPipelineStatuServerResponseModel response);

		ApiPipelineStatuClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStatuServerResponseModel response);

		JsonPatchDocument<ApiPipelineStatuServerRequestModel> CreatePatch(ApiPipelineStatuServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8655c032908b7916b3d17b245f714ba6</Hash>
</Codenesium>*/