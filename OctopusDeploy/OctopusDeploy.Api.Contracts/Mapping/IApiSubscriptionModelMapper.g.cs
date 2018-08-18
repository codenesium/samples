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
    <Hash>b7413e14be3469c96315b85f9f8e1e76</Hash>
</Codenesium>*/