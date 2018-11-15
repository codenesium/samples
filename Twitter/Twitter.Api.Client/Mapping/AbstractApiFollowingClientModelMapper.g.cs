using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public abstract class AbstractApiFollowingModelMapper
	{
		public virtual ApiFollowingClientResponseModel MapClientRequestToResponse(
			int userId,
			ApiFollowingClientRequestModel request)
		{
			var response = new ApiFollowingClientResponseModel();
			response.SetProperties(userId,
			                       request.DateFollowed,
			                       request.Muted);
			return response;
		}

		public virtual ApiFollowingClientRequestModel MapClientResponseToRequest(
			ApiFollowingClientResponseModel response)
		{
			var request = new ApiFollowingClientRequestModel();
			request.SetProperties(
				response.DateFollowed,
				response.Muted);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>a124f808229a4f84066158401273e7ee</Hash>
</Codenesium>*/