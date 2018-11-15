using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>f00d9b274a57c92c214dad2dd49c2d69</Hash>
</Codenesium>*/