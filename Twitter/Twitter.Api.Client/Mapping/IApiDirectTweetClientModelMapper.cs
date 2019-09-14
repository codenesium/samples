using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

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
    <Hash>259534ad9d6925b9222aabcbbda5eda9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/