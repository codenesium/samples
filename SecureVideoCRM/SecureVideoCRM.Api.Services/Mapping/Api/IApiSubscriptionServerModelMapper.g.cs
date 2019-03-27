using Microsoft.AspNetCore.JsonPatch;
using SecureVideoCRMNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public partial interface IApiSubscriptionServerModelMapper
	{
		ApiSubscriptionServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSubscriptionServerRequestModel request);

		ApiSubscriptionServerRequestModel MapServerResponseToRequest(
			ApiSubscriptionServerResponseModel response);

		ApiSubscriptionClientRequestModel MapServerResponseToClientRequest(
			ApiSubscriptionServerResponseModel response);

		JsonPatchDocument<ApiSubscriptionServerRequestModel> CreatePatch(ApiSubscriptionServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d89816da9beb6ee45e1eab51c976e39c</Hash>
</Codenesium>*/