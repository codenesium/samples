using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public class ApiFollowerModelMapper : IApiFollowerModelMapper
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
    <Hash>97c01b840cf84cb7aca0cfb7e2d4b924</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/