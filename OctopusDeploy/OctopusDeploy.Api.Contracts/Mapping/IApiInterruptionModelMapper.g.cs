using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiInterruptionModelMapper
	{
		ApiInterruptionResponseModel MapRequestToResponse(
			string id,
			ApiInterruptionRequestModel request);

		ApiInterruptionRequestModel MapResponseToRequest(
			ApiInterruptionResponseModel response);

		JsonPatchDocument<ApiInterruptionRequestModel> CreatePatch(ApiInterruptionRequestModel model);
	}
}

/*<Codenesium>
    <Hash>203d778d1c92dac58e56e4c1a5ab4f9f</Hash>
</Codenesium>*/