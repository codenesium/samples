using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public class ApiDirectTweetModelMapper : IApiDirectTweetModelMapper
	{
		public virtual ApiDirectTweetClientResponseModel MapClientRequestToResponse(
			int tweetId,
			ApiDirectTweetClientRequestModel request)
		{
			var response = new ApiDirectTweetClientResponseModel();
			response.SetProperties(tweetId,
			                       request.Content,
			                       request.Date,
			                       request.TaggedUserId,
			                       request.Time);
			return response;
		}

		public virtual ApiDirectTweetClientRequestModel MapClientResponseToRequest(
			ApiDirectTweetClientResponseModel response)
		{
			var request = new ApiDirectTweetClientRequestModel();
			request.SetProperties(
				response.Content,
				response.Date,
				response.TaggedUserId,
				response.Time);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>3d4f70a7dbfbd56c0d27a828da0a50c6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/