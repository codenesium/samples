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
    <Hash>0d7ab896d4ca2f3327fdbecb4a388eed</Hash>
</Codenesium>*/