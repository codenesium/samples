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
    <Hash>0154378e580ee3e1d95bd28c2fc41e85</Hash>
</Codenesium>*/