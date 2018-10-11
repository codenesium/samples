using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public abstract class AbstractApiFollowerModelMapper
	{
		public virtual ApiFollowerResponseModel MapRequestToResponse(
			int id,
			ApiFollowerRequestModel request)
		{
			var response = new ApiFollowerResponseModel();
			response.SetProperties(id,
			                       request.Blocked,
			                       request.DateFollowed,
			                       request.FollowRequestStatu,
			                       request.FollowedUserId,
			                       request.FollowingUserId,
			                       request.Muted);
			return response;
		}

		public virtual ApiFollowerRequestModel MapResponseToRequest(
			ApiFollowerResponseModel response)
		{
			var request = new ApiFollowerRequestModel();
			request.SetProperties(
				response.Blocked,
				response.DateFollowed,
				response.FollowRequestStatu,
				response.FollowedUserId,
				response.FollowingUserId,
				response.Muted);
			return request;
		}

		public JsonPatchDocument<ApiFollowerRequestModel> CreatePatch(ApiFollowerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiFollowerRequestModel>();
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
    <Hash>8eeafddc7d827c2a009a1ef4f9f35c31</Hash>
</Codenesium>*/