using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public abstract class AbstractApiFollowerModelMapper
	{
		public virtual ApiFollowerClientResponseModel MapClientRequestToResponse(
			int id,
			ApiFollowerClientRequestModel request)
		{
			var response = new ApiFollowerClientResponseModel();
			response.SetProperties(id,
			                       request.Blocked,
			                       request.DateFollowed,
			                       request.FollowedUserId,
			                       request.FollowingUserId,
			                       request.FollowRequestStatu,
			                       request.Muted);
			return response;
		}

		public virtual ApiFollowerClientRequestModel MapClientResponseToRequest(
			ApiFollowerClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>05bdb9ee82bdfe75dc5750e8c8d9e0d8</Hash>
</Codenesium>*/