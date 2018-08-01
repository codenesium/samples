using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiMachinePolicyModelMapper
	{
		ApiMachinePolicyResponseModel MapRequestToResponse(
			string id,
			ApiMachinePolicyRequestModel request);

		ApiMachinePolicyRequestModel MapResponseToRequest(
			ApiMachinePolicyResponseModel response);

		JsonPatchDocument<ApiMachinePolicyRequestModel> CreatePatch(ApiMachinePolicyRequestModel model);
	}
}

/*<Codenesium>
    <Hash>eb37d37d29b7cadefa7f6e3151123e01</Hash>
</Codenesium>*/