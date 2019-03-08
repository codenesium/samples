using ESPIOTPostgresNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Services
{
	public partial interface IApiDeviceServerModelMapper
	{
		ApiDeviceServerResponseModel MapServerRequestToResponse(
			int id,
			ApiDeviceServerRequestModel request);

		ApiDeviceServerRequestModel MapServerResponseToRequest(
			ApiDeviceServerResponseModel response);

		ApiDeviceClientRequestModel MapServerResponseToClientRequest(
			ApiDeviceServerResponseModel response);

		JsonPatchDocument<ApiDeviceServerRequestModel> CreatePatch(ApiDeviceServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5b8b6e58a3e846925ed319db7fb80626</Hash>
</Codenesium>*/