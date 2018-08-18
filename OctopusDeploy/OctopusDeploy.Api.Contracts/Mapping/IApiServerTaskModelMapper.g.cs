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
    <Hash>d0297483c171a7e324ee87ae5af6fce9</Hash>
</Codenesium>*/