using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public partial interface IApiTweetModelMapper
	{
		ApiTweetResponseModel MapRequestToResponse(
			int tweetId,
			ApiTweetRequestModel request);

		ApiTweetRequestModel MapResponseToRequest(
			ApiTweetResponseModel response);

		JsonPatchDocument<ApiTweetRequestModel> CreatePatch(ApiTweetRequestModel model);
	}
}

/*<Codenesium>
    <Hash>343e6398122c6556037e2410a519042e</Hash>
</Codenesium>*/