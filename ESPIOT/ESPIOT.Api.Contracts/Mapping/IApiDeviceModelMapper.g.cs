using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Contracts
{
	public interface IApiDeviceModelMapper
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
    <Hash>49d4746175c60006b3ccdfe54ce4f3af</Hash>
</Codenesium>*/