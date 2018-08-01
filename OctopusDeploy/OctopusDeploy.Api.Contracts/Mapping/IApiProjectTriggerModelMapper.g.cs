using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiProjectTriggerModelMapper
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
    <Hash>956352c84072312ec8d4b02c772c2ccb</Hash>
</Codenesium>*/