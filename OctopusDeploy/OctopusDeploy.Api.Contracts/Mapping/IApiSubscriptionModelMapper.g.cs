using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiSubscriptionModelMapper
	{
		ApiSubscriptionResponseModel MapRequestToResponse(
			string id,
			ApiSubscriptionRequestModel request);

		ApiSubscriptionRequestModel MapResponseToRequest(
			ApiSubscriptionResponseModel response);

		JsonPatchDocument<ApiSubscriptionRequestModel> CreatePatch(ApiSubscriptionRequestModel model);
	}
}

/*<Codenesium>
    <Hash>96c27cdc795a3d4be53b8d0aa96d52f6</Hash>
</Codenesium>*/