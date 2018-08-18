using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiLifecycleModelMapper
	{
		ApiLifecycleResponseModel MapRequestToResponse(
			string id,
			ApiLifecycleRequestModel request);

		ApiLifecycleRequestModel MapResponseToRequest(
			ApiLifecycleResponseModel response);

		JsonPatchDocument<ApiLifecycleRequestModel> CreatePatch(ApiLifecycleRequestModel model);
	}
}

/*<Codenesium>
    <Hash>84f67ada20f2e4a698586f683fab8d20</Hash>
</Codenesium>*/