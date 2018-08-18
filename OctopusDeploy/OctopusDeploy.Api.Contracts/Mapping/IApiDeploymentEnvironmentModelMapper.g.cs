using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiDeploymentEnvironmentModelMapper
	{
		ApiDeploymentEnvironmentResponseModel MapRequestToResponse(
			string id,
			ApiDeploymentEnvironmentRequestModel request);

		ApiDeploymentEnvironmentRequestModel MapResponseToRequest(
			ApiDeploymentEnvironmentResponseModel response);

		JsonPatchDocument<ApiDeploymentEnvironmentRequestModel> CreatePatch(ApiDeploymentEnvironmentRequestModel model);
	}
}

/*<Codenesium>
    <Hash>ca90058264157a0666b4b1709919ab8a</Hash>
</Codenesium>*/