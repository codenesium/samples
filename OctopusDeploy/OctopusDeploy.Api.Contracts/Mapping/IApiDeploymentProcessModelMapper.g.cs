using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiDeploymentProcessModelMapper
	{
		ApiDeploymentProcessResponseModel MapRequestToResponse(
			string id,
			ApiDeploymentProcessRequestModel request);

		ApiDeploymentProcessRequestModel MapResponseToRequest(
			ApiDeploymentProcessResponseModel response);

		JsonPatchDocument<ApiDeploymentProcessRequestModel> CreatePatch(ApiDeploymentProcessRequestModel model);
	}
}

/*<Codenesium>
    <Hash>0217f2820e714f9c95c8ac1ab341e23b</Hash>
</Codenesium>*/