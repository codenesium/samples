using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiEventStatuServerModelMapper
	{
		ApiEventStatuServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEventStatuServerRequestModel request);

		ApiEventStatuServerRequestModel MapServerResponseToRequest(
			ApiEventStatuServerResponseModel response);

		ApiEventStatuClientRequestModel MapServerResponseToClientRequest(
			ApiEventStatuServerResponseModel response);

		JsonPatchDocument<ApiEventStatuServerRequestModel> CreatePatch(ApiEventStatuServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>72aef39eb642d5956c173cf32d31d4c5</Hash>
</Codenesium>*/