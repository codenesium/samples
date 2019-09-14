using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public class ApiFollowerServerModelMapper : IApiFollowerServerModelMapper
	{
		public virtual ApiFollowerServerResponseModel MapServerRequestToResponse(
			int id,
			ApiFollowerServerRequestModel request)
		{
			var response = new ApiFollowerServerResponseModel();
			response.SetProperties(id,
			                       request.Blocked,
			                       request.DateFollowed,
			                       request.FollowedUserId,
			                       request.FollowingUserId,
			                       request.FollowRequestStatu,
			                       request.Muted);
			return response;
		}

		public virtual ApiFollowerServerRequestModel MapServerResponseToRequest(
			ApiFollowerServerResponseModel response)
		{
			var request = new ApiFollowerServerRequestModel();
			request.SetProperties(
				response.Blocked,
				response.DateFollowed,
				response.FollowedUserId,
				response.FollowingUserId,
				response.FollowRequestStatu,
				response.Muted);
			return request;
		}

		public virtual ApiFollowerClientRequestModel MapServerResponseToClientRequest(
			ApiFollowerServerResponseModel response)
		{
			var request = new ApiFollowerClientRequestModel();
			request.SetProperties(
				response.Blocked,
				response.DateFollowed,
				response.FollowedUserId,
				response.FollowingUserId,
				response.FollowRequestStatu,
				response.Muted);
			return request;
		}

		public JsonPatchDocument<ApiFollowerServerRequestModel> CreatePatch(ApiFollowerServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiFollowerServerRequestModel>();
			patch.Replace(x => x.Blocked, model.Blocked);
			patch.Replace(x => x.DateFollowed, model.DateFollowed);
			patch.Replace(x => x.FollowRequestStatu, model.FollowRequestStatu);
			patch.Replace(x => x.FollowedUserId, model.FollowedUserId);
			patch.Replace(x => x.FollowingUserId, model.FollowingUserId);
			patch.Replace(x => x.Muted, model.Muted);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>ba1636816734559bf702a30e5030810f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/