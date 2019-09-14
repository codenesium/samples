using SecureVideoCRMNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Client
{
	public partial interface IApiSubscriptionModelMapper
	{
		ApiSubscriptionClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSubscriptionClientRequestModel request);

		ApiSubscriptionClientRequestModel MapClientResponseToRequest(
			ApiSubscriptionClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>55646c3f3ce6ee5d8e4dc5ecda6372e7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/