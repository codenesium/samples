using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiTeamServerModelMapper
	{
		ApiTeamServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTeamServerRequestModel request);

		ApiTeamServerRequestModel MapServerResponseToRequest(
			ApiTeamServerResponseModel response);

		ApiTeamClientRequestModel MapServerResponseToClientRequest(
			ApiTeamServerResponseModel response);

		JsonPatchDocument<ApiTeamServerRequestModel> CreatePatch(ApiTeamServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8c331c06c5d466d8ea2ba75db5a9f19a</Hash>
</Codenesium>*/