using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Contracts
{
	public partial interface IApiDeviceModelMapper
	{
		ApiDeviceResponseModel MapRequestToResponse(
			int id,
			ApiDeviceRequestModel request);

		ApiDeviceRequestModel MapResponseToRequest(
			ApiDeviceResponseModel response);

		JsonPatchDocument<ApiDeviceRequestModel> CreatePatch(ApiDeviceRequestModel model);
	}
}

/*<Codenesium>
    <Hash>85c120b205ee6d9e58ac00805ba981ea</Hash>
</Codenesium>*/