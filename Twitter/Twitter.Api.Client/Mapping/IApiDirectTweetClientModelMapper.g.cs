using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public partial interface IApiDirectTweetModelMapper
	{
		ApiDirectTweetClientResponseModel MapClientRequestToResponse(
			int tweetId,
			ApiDirectTweetClientRequestModel request);

		ApiDirectTweetClientRequestModel MapClientResponseToRequest(
			ApiDirectTweetClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>99c6e146703aba293a63decc98efbe1a</Hash>
</Codenesium>*/