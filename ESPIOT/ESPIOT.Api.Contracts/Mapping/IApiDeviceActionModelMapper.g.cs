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
    <Hash>739396473414ce2df7cd26bc0e50886a</Hash>
</Codenesium>*/