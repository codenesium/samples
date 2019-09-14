using Microsoft.AspNetCore.JsonPatch;
using SecureVideoCRMNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public class ApiSubscriptionServerModelMapper : IApiSubscriptionServerModelMapper
	{
		public virtual ApiSubscriptionServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSubscriptionServerRequestModel request)
		{
			var response = new ApiSubscriptionServerResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.StripePlanName);
			return response;
		}

		public virtual ApiSubscriptionServerRequestModel MapServerResponseToRequest(
			ApiSubscriptionServerResponseModel response)
		{
			var request = new ApiSubscriptionServerRequestModel();
			request.SetProperties(
				response.Name,
				response.StripePlanName);
			return request;
		}

		public virtual ApiSubscriptionClientRequestModel MapServerResponseToClientRequest(
			ApiSubscriptionServerResponseModel response)
		{
			var request = new ApiSubscriptionClientRequestModel();
			request.SetProperties(
				response.Name,
				response.StripePlanName);
			return request;
		}

		public JsonPatchDocument<ApiSubscriptionServerRequestModel> CreatePatch(ApiSubscriptionServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSubscriptionServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.StripePlanName, model.StripePlanName);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>c2a0ff35b188186465cf9b2764f1365b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/