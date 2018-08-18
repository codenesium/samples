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
    <Hash>e072662a8fe47a55dd67ac532febf3e7</Hash>
</Codenesium>*/