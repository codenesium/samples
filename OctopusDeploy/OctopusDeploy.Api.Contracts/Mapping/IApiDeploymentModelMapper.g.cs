using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiDeploymentModelMapper
	{
		ApiDeploymentResponseModel MapRequestToResponse(
			string id,
			ApiDeploymentRequestModel request);

		ApiDeploymentRequestModel MapResponseToRequest(
			ApiDeploymentResponseModel response);

		JsonPatchDocument<ApiDeploymentRequestModel> CreatePatch(ApiDeploymentRequestModel model);
	}
}

/*<Codenesium>
    <Hash>63031ffc193e3fcea3eda526fe1578c6</Hash>
</Codenesium>*/