using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Client
{
	public class ApiUserModelMapper : IApiUserModelMapper
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
    <Hash>ae2dada8cb78532e45bfa81df6bca5fb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/