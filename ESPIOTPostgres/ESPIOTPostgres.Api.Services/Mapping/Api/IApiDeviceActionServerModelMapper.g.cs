using ESPIOTPostgresNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Services
{
	public partial interface IApiDeviceActionServerModelMapper
	{
		ApiDeviceActionServerResponseModel MapServerRequestToResponse(
			int id,
			ApiDeviceActionServerRequestModel request);

		ApiDeviceActionServerRequestModel MapServerResponseToRequest(
			ApiDeviceActionServerResponseModel response);

		ApiDeviceActionClientRequestModel MapServerResponseToClientRequest(
			ApiDeviceActionServerResponseModel response);

		JsonPatchDocument<ApiDeviceActionServerRequestModel> CreatePatch(ApiDeviceActionServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a55c0caaca277b01390a6bf0c8d45cdc</Hash>
</Codenesium>*/