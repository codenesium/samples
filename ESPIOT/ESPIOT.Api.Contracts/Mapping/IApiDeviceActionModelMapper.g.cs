using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Contracts
{
	public interface IApiDeviceActionModelMapper
	{
		ApiDeviceActionResponseModel MapRequestToResponse(
			int id,
			ApiDeviceActionRequestModel request);

		ApiDeviceActionRequestModel MapResponseToRequest(
			ApiDeviceActionResponseModel response);

		JsonPatchDocument<ApiDeviceActionRequestModel> CreatePatch(ApiDeviceActionRequestModel model);
	}
}

/*<Codenesium>
    <Hash>39ddaeec1e731c250f7d84ebb4816514</Hash>
</Codenesium>*/