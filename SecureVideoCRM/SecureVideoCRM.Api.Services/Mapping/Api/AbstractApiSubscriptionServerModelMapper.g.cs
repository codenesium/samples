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
			                       request.Name);
			return response;
		}

		public virtual ApiSubscriptionServerRequestModel MapServerResponseToRequest(
			ApiSubscriptionServerResponseModel response)
		{
			var request = new ApiSubscriptionServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiSubscriptionClientRequestModel MapServerResponseToClientRequest(
			ApiSubscriptionServerResponseModel response)
		{
			var request = new ApiSubscriptionClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiSubscriptionServerRequestModel> CreatePatch(ApiSubscriptionServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSubscriptionServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f42e89643aaeb1a983e5b95629d2721d</Hash>
</Codenesium>*/