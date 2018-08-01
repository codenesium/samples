using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiServerTaskModelMapper
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
    <Hash>8331092545b92f0d9da0b25d76af46f9</Hash>
</Codenesium>*/