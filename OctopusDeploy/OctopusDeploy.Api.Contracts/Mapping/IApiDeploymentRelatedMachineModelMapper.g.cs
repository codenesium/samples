using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiDeploymentRelatedMachineModelMapper
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
    <Hash>50b43cc85d0096240ea54484abcb3ff9</Hash>
</Codenesium>*/