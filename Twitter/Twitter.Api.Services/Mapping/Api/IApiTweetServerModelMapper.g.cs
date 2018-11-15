using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public partial interface IApiTweetServerModelMapper
	{
		ApiTweetServerResponseModel MapServerRequestToResponse(
			int tweetId,
			ApiTweetServerRequestModel request);

		ApiTweetServerRequestModel MapServerResponseToRequest(
			ApiTweetServerResponseModel response);

		ApiTweetClientRequestModel MapServerResponseToClientRequest(
			ApiTweetServerResponseModel response);

		JsonPatchDocument<ApiTweetServerRequestModel> CreatePatch(ApiTweetServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>fa878e30d9c20f668092cb2cec303d7b</Hash>
</Codenesium>*/