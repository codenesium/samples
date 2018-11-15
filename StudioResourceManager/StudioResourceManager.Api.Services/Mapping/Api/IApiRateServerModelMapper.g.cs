using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiRateServerModelMapper
	{
		ApiRateServerResponseModel MapServerRequestToResponse(
			int id,
			ApiRateServerRequestModel request);

		ApiRateServerRequestModel MapServerResponseToRequest(
			ApiRateServerResponseModel response);

		ApiRateClientRequestModel MapServerResponseToClientRequest(
			ApiRateServerResponseModel response);

		JsonPatchDocument<ApiRateServerRequestModel> CreatePatch(ApiRateServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8fce06f28dc8b84d8ddbb03f0ed6ab97</Hash>
</Codenesium>*/