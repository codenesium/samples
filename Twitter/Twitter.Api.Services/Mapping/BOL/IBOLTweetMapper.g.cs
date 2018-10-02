using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IBOLTweetMapper
	{
		BOTweet MapModelToBO(
			int tweetId,
			ApiTweetRequestModel model);

		ApiTweetResponseModel MapBOToModel(
			BOTweet boTweet);

		List<ApiTweetResponseModel> MapBOToModel(
			List<BOTweet> items);
	}
}

/*<Codenesium>
    <Hash>cbb5cde302a06e8d47193d8c1e2dd7a6</Hash>
</Codenesium>*/