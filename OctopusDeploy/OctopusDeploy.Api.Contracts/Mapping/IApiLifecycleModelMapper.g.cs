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
    <Hash>6e3564448e00111346238e169d0f7c0e</Hash>
</Codenesium>*/