using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiEventStatusServerModelMapper
	{
		ApiEventStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEventStatusServerRequestModel request);

		ApiEventStatusServerRequestModel MapServerResponseToRequest(
			ApiEventStatusServerResponseModel response);

		ApiEventStatusClientRequestModel MapServerResponseToClientRequest(
			ApiEventStatusServerResponseModel response);

		JsonPatchDocument<ApiEventStatusServerRequestModel> CreatePatch(ApiEventStatusServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8c6cdb0003ade49f1329274002ce2565</Hash>
</Codenesium>*/