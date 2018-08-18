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
    <Hash>b3304401677a54345252430ac73f493a</Hash>
</Codenesium>*/