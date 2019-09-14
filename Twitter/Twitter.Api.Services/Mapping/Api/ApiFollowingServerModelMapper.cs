using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public class ApiFollowingServerModelMapper : IApiFollowingServerModelMapper
	{
		public virtual ApiFollowingServerResponseModel MapServerRequestToResponse(
			int userId,
			ApiFollowingServerRequestModel request)
		{
			var response = new ApiFollowingServerResponseModel();
			response.SetProperties(userId,
			                       request.DateFollowed,
			                       request.Muted);
			return response;
		}

		public virtual ApiFollowingServerRequestModel MapServerResponseToRequest(
			ApiFollowingServerResponseModel response)
		{
			var request = new ApiFollowingServerRequestModel();
			request.SetProperties(
				response.DateFollowed,
				response.Muted);
			return request;
		}

		public virtual ApiFollowingClientRequestModel MapServerResponseToClientRequest(
			ApiFollowingServerResponseModel response)
		{
			var request = new ApiFollowingClientRequestModel();
			request.SetProperties(
				response.DateFollowed,
				response.Muted);
			return request;
		}

		public JsonPatchDocument<ApiFollowingServerRequestModel> CreatePatch(ApiFollowingServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiFollowingServerRequestModel>();
			patch.Replace(x => x.DateFollowed, model.DateFollowed);
			patch.Replace(x => x.Muted, model.Muted);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>269eb18b6695651ee8ea48bb0bf2b180</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/