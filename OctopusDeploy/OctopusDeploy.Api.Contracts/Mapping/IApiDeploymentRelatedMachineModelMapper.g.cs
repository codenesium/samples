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
    <Hash>c6a515874a93067bdf659d2f0ec210b9</Hash>
</Codenesium>*/