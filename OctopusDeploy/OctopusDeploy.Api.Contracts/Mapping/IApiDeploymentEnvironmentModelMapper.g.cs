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
    <Hash>9d1e266adc55ceb4c2ff3ab43cb6e910</Hash>
</Codenesium>*/