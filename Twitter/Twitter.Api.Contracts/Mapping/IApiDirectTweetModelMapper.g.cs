using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public partial interface IApiDirectTweetModelMapper
	{
		ApiDirectTweetResponseModel MapRequestToResponse(
			int tweetId,
			ApiDirectTweetRequestModel request);

		ApiDirectTweetRequestModel MapResponseToRequest(
			ApiDirectTweetResponseModel response);

		JsonPatchDocument<ApiDirectTweetRequestModel> CreatePatch(ApiDirectTweetRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a9b0cd349ba83c108c15882996276d05</Hash>
</Codenesium>*/