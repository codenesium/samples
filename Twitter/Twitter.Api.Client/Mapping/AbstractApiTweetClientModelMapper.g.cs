using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public abstract class AbstractApiTweetModelMapper
	{
		public virtual ApiTweetClientResponseModel MapClientRequestToResponse(
			int tweetId,
			ApiTweetClientRequestModel request)
		{
			var response = new ApiTweetClientResponseModel();
			response.SetProperties(tweetId,
			                       request.Content,
			                       request.Date,
			                       request.LocationId,
			                       request.Time,
			                       request.UserUserId);
			return response;
		}

		public virtual ApiTweetClientRequestModel MapClientResponseToRequest(
			ApiTweetClientResponseModel response)
		{
			var request = new ApiTweetClientRequestModel();
			request.SetProperties(
				response.Content,
				response.Date,
				response.LocationId,
				response.Time,
				response.UserUserId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>731b04060584a599249fe121a2af8c84</Hash>
</Codenesium>*/