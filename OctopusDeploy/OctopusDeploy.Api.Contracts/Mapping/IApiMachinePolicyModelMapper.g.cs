using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiMachinePolicyModelMapper
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
    <Hash>d07352ba72eaefc7f3031969a6066ce8</Hash>
</Codenesium>*/