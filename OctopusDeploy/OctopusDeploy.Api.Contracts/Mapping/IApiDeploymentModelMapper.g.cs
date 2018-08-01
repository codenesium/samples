using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiDeploymentModelMapper
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
    <Hash>53c2619f10f476353e6eee9530f59560</Hash>
</Codenesium>*/