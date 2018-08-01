using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiMachineModelMapper
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
    <Hash>284be6b3f665eff8cea9c6473eb11fe8</Hash>
</Codenesium>*/