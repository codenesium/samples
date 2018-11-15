using ESPIOTNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
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
    <Hash>dee5a6582b022248ba06b055e09486c3</Hash>
</Codenesium>*/