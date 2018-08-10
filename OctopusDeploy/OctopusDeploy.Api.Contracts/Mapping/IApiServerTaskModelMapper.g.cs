using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiServerTaskModelMapper
	{
		ApiServerTaskResponseModel MapRequestToResponse(
			string id,
			ApiServerTaskRequestModel request);

		ApiServerTaskRequestModel MapResponseToRequest(
			ApiServerTaskResponseModel response);

		JsonPatchDocument<ApiServerTaskRequestModel> CreatePatch(ApiServerTaskRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b6dd4098333bec491bed889ae0f9718b</Hash>
</Codenesium>*/