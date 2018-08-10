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
    <Hash>7cd9130ad863247b18fd075406a48f22</Hash>
</Codenesium>*/