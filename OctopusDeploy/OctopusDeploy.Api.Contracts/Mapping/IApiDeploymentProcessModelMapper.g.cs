using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiDeploymentProcessModelMapper
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
    <Hash>8cc9f2a9793e4d71b8f02c97b3182238</Hash>
</Codenesium>*/