using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiSubscriptionModelMapper
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
    <Hash>0f11cbe421dc0b95d18ef516e6222803</Hash>
</Codenesium>*/