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
    <Hash>7a83ba051a77365229fbf53fd46a2bd0</Hash>
</Codenesium>*/