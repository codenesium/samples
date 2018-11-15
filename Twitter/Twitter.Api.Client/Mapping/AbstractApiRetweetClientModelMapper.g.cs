using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public abstract class AbstractApiRetweetModelMapper
	{
		public virtual ApiRetweetClientResponseModel MapClientRequestToResponse(
			int id,
			ApiRetweetClientRequestModel request)
		{
			var response = new ApiRetweetClientResponseModel();
			response.SetProperties(id,
			                       request.Date,
			                       request.RetwitterUserId,
			                       request.Time,
			                       request.TweetTweetId);
			return response;
		}

		public virtual ApiRetweetClientRequestModel MapClientResponseToRequest(
			ApiRetweetClientResponseModel response)
		{
			var request = new ApiRetweetClientRequestModel();
			request.SetProperties(
				response.Date,
				response.RetwitterUserId,
				response.Time,
				response.TweetTweetId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>6dee56b17b6576a03d93366398d5a5d7</Hash>
</Codenesium>*/