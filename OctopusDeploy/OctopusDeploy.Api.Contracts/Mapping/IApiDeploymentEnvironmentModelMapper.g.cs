using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiDeploymentEnvironmentModelMapper
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
    <Hash>b801002f1d91d0bf9d206c881e4b5324</Hash>
</Codenesium>*/