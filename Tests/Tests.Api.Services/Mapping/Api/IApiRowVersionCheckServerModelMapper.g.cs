using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public partial interface IApiRowVersionCheckServerModelMapper
	{
		ApiRowVersionCheckServerResponseModel MapServerRequestToResponse(
			int id,
			ApiRowVersionCheckServerRequestModel request);

		ApiRowVersionCheckServerRequestModel MapServerResponseToRequest(
			ApiRowVersionCheckServerResponseModel response);

		ApiRowVersionCheckClientRequestModel MapServerResponseToClientRequest(
			ApiRowVersionCheckServerResponseModel response);

		JsonPatchDocument<ApiRowVersionCheckServerRequestModel> CreatePatch(ApiRowVersionCheckServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>ea7740292f21ea91ad057b1de73c4065</Hash>
</Codenesium>*/