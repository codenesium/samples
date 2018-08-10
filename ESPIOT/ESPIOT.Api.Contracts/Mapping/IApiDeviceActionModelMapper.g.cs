using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Contracts
{
	public partial interface IApiDeviceActionModelMapper
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
    <Hash>ffcb1c41da347b9784898573179882f8</Hash>
</Codenesium>*/