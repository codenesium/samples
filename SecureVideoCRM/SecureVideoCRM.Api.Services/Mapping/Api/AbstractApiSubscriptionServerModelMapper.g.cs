using Microsoft.AspNetCore.JsonPatch;
using SecureVideoCRMNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public abstract class AbstractApiSubscriptionServerModelMapper
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
    <Hash>9c3e76ac7851c2c1528b0a9d8c793fcd</Hash>
</Codenesium>*/