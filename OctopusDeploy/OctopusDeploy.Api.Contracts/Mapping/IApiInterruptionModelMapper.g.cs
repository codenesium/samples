using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiInterruptionModelMapper
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
    <Hash>58b403f0d1c37b67e2841652e067ba0b</Hash>
</Codenesium>*/