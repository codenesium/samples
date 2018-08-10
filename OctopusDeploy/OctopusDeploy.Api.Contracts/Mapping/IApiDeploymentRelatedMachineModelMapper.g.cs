using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiDeploymentRelatedMachineModelMapper
	{
		ApiDeploymentRelatedMachineResponseModel MapRequestToResponse(
			int id,
			ApiDeploymentRelatedMachineRequestModel request);

		ApiDeploymentRelatedMachineRequestModel MapResponseToRequest(
			ApiDeploymentRelatedMachineResponseModel response);

		JsonPatchDocument<ApiDeploymentRelatedMachineRequestModel> CreatePatch(ApiDeploymentRelatedMachineRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b39d73f170f5c637060c34f99d6d3e7f</Hash>
</Codenesium>*/