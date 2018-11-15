using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiMachineServerModelMapper
	{
		ApiMachineServerResponseModel MapServerRequestToResponse(
			int id,
			ApiMachineServerRequestModel request);

		ApiMachineServerRequestModel MapServerResponseToRequest(
			ApiMachineServerResponseModel response);

		ApiMachineClientRequestModel MapServerResponseToClientRequest(
			ApiMachineServerResponseModel response);

		JsonPatchDocument<ApiMachineServerRequestModel> CreatePatch(ApiMachineServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d3a2b6bb18417ac3b5f28a93724cac82</Hash>
</Codenesium>*/