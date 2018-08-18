using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiDeploymentHistoryModelMapper
	{
		ApiDeploymentHistoryResponseModel MapRequestToResponse(
			string deploymentId,
			ApiDeploymentHistoryRequestModel request);

		ApiDeploymentHistoryRequestModel MapResponseToRequest(
			ApiDeploymentHistoryResponseModel response);

		JsonPatchDocument<ApiDeploymentHistoryRequestModel> CreatePatch(ApiDeploymentHistoryRequestModel model);
	}
}

/*<Codenesium>
    <Hash>17eaa7fa25374b90130458cd1df26a89</Hash>
</Codenesium>*/