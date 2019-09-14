using Microsoft.AspNetCore.JsonPatch;
using SecureVideoCRMNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public class ApiUserServerModelMapper : IApiUserServerModelMapper
	{
		public virtual ApiUserServerResponseModel MapServerRequestToResponse(
			int id,
			ApiUserServerRequestModel request)
		{
			var response = new ApiUserServerResponseModel();
			response.SetProperties(id,
			                       request.Email,
			                       request.Password,
			                       request.StripeCustomerId,
			                       request.SubscriptionTypeId);
			return response;
		}

		public virtual ApiUserServerRequestModel MapServerResponseToRequest(
			ApiUserServerResponseModel response)
		{
			var request = new ApiUserServerRequestModel();
			request.SetProperties(
				response.Email,
				response.Password,
				response.StripeCustomerId,
				response.SubscriptionTypeId);
			return request;
		}

		public virtual ApiUserClientRequestModel MapServerResponseToClientRequest(
			ApiUserServerResponseModel response)
		{
			var request = new ApiUserClientRequestModel();
			request.SetProperties(
				response.Email,
				response.Password,
				response.StripeCustomerId,
				response.SubscriptionTypeId);
			return request;
		}

		public JsonPatchDocument<ApiUserServerRequestModel> CreatePatch(ApiUserServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiUserServerRequestModel>();
			patch.Replace(x => x.Email, model.Email);
			patch.Replace(x => x.Password, model.Password);
			patch.Replace(x => x.StripeCustomerId, model.StripeCustomerId);
			patch.Replace(x => x.SubscriptionTypeId, model.SubscriptionTypeId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e5f07ffd153e2558aabf366783817d85</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/