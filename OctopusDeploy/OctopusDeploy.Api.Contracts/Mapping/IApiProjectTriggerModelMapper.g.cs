using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiProjectTriggerModelMapper
	{
		ApiProjectTriggerResponseModel MapRequestToResponse(
			string id,
			ApiProjectTriggerRequestModel request);

		ApiProjectTriggerRequestModel MapResponseToRequest(
			ApiProjectTriggerResponseModel response);

		JsonPatchDocument<ApiProjectTriggerRequestModel> CreatePatch(ApiProjectTriggerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8123c90ca9f0a45186f7f48675751018</Hash>
</Codenesium>*/