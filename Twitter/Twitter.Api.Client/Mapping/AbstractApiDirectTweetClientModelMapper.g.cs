using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public abstract class AbstractApiDirectTweetModelMapper
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
    <Hash>c7f9738ee54b56b212e315a94a061039</Hash>
</Codenesium>*/