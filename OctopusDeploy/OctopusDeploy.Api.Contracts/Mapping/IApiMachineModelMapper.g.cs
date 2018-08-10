using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiMachineModelMapper
	{
		ApiMachineResponseModel MapRequestToResponse(
			string id,
			ApiMachineRequestModel request);

		ApiMachineRequestModel MapResponseToRequest(
			ApiMachineResponseModel response);

		JsonPatchDocument<ApiMachineRequestModel> CreatePatch(ApiMachineRequestModel model);
	}
}

/*<Codenesium>
    <Hash>57996c7cefb7838ff7c762ebf4a4a1f0</Hash>
</Codenesium>*/