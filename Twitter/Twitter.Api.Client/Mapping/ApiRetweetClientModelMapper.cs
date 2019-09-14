using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public class ApiRetweetModelMapper : IApiRetweetModelMapper
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
    <Hash>8318570904a70ed4ffaf90c3d5dc56de</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/