using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiMachineRefTeamServerModelMapper
	{
		ApiMachineRefTeamServerResponseModel MapServerRequestToResponse(
			int id,
			ApiMachineRefTeamServerRequestModel request);

		ApiMachineRefTeamServerRequestModel MapServerResponseToRequest(
			ApiMachineRefTeamServerResponseModel response);

		ApiMachineRefTeamClientRequestModel MapServerResponseToClientRequest(
			ApiMachineRefTeamServerResponseModel response);

		JsonPatchDocument<ApiMachineRefTeamServerRequestModel> CreatePatch(ApiMachineRefTeamServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>37868d9e86e64f2d03b63ebafeeb1566</Hash>
</Codenesium>*/