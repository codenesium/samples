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
    <Hash>b86b0e92760687d96b9ba1365c39abbc</Hash>
</Codenesium>*/