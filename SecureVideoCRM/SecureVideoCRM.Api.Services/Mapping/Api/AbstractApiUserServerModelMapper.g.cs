using Microsoft.AspNetCore.JsonPatch;
using SecureVideoCRMNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public abstract class AbstractApiUserServerModelMapper
	{
		public virtual ApiUserServerResponseModel MapServerRequestToResponse(
			int id,
			ApiUserServerRequestModel request)
		{
			var response = new ApiUserServerResponseModel();
			response.SetProperties(id,
			                       request.Email,
			                       request.Password,
			                       request.SubscriptionId);
			return response;
		}

		public virtual ApiUserServerRequestModel MapServerResponseToRequest(
			ApiUserServerResponseModel response)
		{
			var request = new ApiUserServerRequestModel();
			request.SetProperties(
				response.Email,
				response.Password,
				response.SubscriptionId);
			return request;
		}

		public virtual ApiUserClientRequestModel MapServerResponseToClientRequest(
			ApiUserServerResponseModel response)
		{
			var request = new ApiUserClientRequestModel();
			request.SetProperties(
				response.Email,
				response.Password,
				response.SubscriptionId);
			return request;
		}

		public JsonPatchDocument<ApiUserServerRequestModel> CreatePatch(ApiUserServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiUserServerRequestModel>();
			patch.Replace(x => x.Email, model.Email);
			patch.Replace(x => x.Password, model.Password);
			patch.Replace(x => x.SubscriptionId, model.SubscriptionId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>86905be13cc3bcf048ca4151225c1a11</Hash>
</Codenesium>*/