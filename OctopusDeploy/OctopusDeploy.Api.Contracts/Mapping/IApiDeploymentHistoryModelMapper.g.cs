using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiDeploymentHistoryModelMapper
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
    <Hash>4cfd81ad0e2996c9ee56fd0823fbfbc8</Hash>
</Codenesium>*/