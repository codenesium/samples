using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

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
    <Hash>f45d3280a21f8e9a9f8606be32ffaa2b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/