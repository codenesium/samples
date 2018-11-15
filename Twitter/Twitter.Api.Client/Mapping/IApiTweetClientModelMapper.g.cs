using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public partial interface IApiTweetModelMapper
	{
		ApiTweetClientResponseModel MapClientRequestToResponse(
			int tweetId,
			ApiTweetClientRequestModel request);

		ApiTweetClientRequestModel MapClientResponseToRequest(
			ApiTweetClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>f6c634a0c5c622f31246b2615efb1d65</Hash>
</Codenesium>*/