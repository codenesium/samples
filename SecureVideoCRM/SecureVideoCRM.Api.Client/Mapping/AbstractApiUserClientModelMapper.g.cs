using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Client
{
	public abstract class AbstractApiUserModelMapper
	{
		public virtual ApiUserClientResponseModel MapClientRequestToResponse(
			int id,
			ApiUserClientRequestModel request)
		{
			var response = new ApiUserClientResponseModel();
			response.SetProperties(id,
			                       request.Email,
			                       request.Password,
			                       request.StripeCustomerId,
			                       request.SubscriptionTypeId);
			return response;
		}

		public virtual ApiUserClientRequestModel MapClientResponseToRequest(
			ApiUserClientResponseModel response)
		{
			var request = new ApiUserClientRequestModel();
			request.SetProperties(
				response.Email,
				response.Password,
				response.StripeCustomerId,
				response.SubscriptionTypeId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>d767d52c66879bf501d8948796a9f368</Hash>
</Codenesium>*/