using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractApiFollowerServerModelMapper
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
    <Hash>a5b3f53e40847f13d99caa0f4498a49a</Hash>
</Codenesium>*/