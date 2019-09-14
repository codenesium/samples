using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public class ApiTweetModelMapper : IApiTweetModelMapper
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
    <Hash>1a135c2b4265977436964ebf9e3c0f6a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/