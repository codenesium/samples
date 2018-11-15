using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public partial interface IApiDirectTweetServerModelMapper
	{
		ApiDirectTweetServerResponseModel MapServerRequestToResponse(
			int tweetId,
			ApiDirectTweetServerRequestModel request);

		ApiDirectTweetServerRequestModel MapServerResponseToRequest(
			ApiDirectTweetServerResponseModel response);

		ApiDirectTweetClientRequestModel MapServerResponseToClientRequest(
			ApiDirectTweetServerResponseModel response);

		JsonPatchDocument<ApiDirectTweetServerRequestModel> CreatePatch(ApiDirectTweetServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a89f3ea2748a205bbbfd997249b383b4</Hash>
</Codenesium>*/