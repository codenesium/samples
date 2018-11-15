using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiStudioServerModelMapper
	{
		ApiStudioServerResponseModel MapServerRequestToResponse(
			int id,
			ApiStudioServerRequestModel request);

		ApiStudioServerRequestModel MapServerResponseToRequest(
			ApiStudioServerResponseModel response);

		ApiStudioClientRequestModel MapServerResponseToClientRequest(
			ApiStudioServerResponseModel response);

		JsonPatchDocument<ApiStudioServerRequestModel> CreatePatch(ApiStudioServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3a1a389e04ee22ff843d84735d339408</Hash>
</Codenesium>*/