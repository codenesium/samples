using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>58458c06b6680305b3df73f1b19ea3c1</Hash>
</Codenesium>*/