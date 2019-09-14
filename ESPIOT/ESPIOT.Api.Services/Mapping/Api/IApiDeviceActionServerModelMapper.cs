using ESPIOTNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
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
    <Hash>0d237a4b00d99e3fb4fe72b4c7ace72b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/