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
			                       request.SubscriptionId);
			return response;
		}

		public virtual ApiUserClientRequestModel MapClientResponseToRequest(
			ApiUserClientResponseModel response)
		{
			var request = new ApiUserClientRequestModel();
			request.SetProperties(
				response.Email,
				response.Password,
				response.SubscriptionId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>5cc7af3b0b5c09f46a450366c3c55993</Hash>
</Codenesium>*/