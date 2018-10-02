using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IBOLDirectTweetMapper
	{
		BODirectTweet MapModelToBO(
			int tweetId,
			ApiDirectTweetRequestModel model);

		ApiDirectTweetResponseModel MapBOToModel(
			BODirectTweet boDirectTweet);

		List<ApiDirectTweetResponseModel> MapBOToModel(
			List<BODirectTweet> items);
	}
}

/*<Codenesium>
    <Hash>cf159f24e288487d37eaf65e806f9705</Hash>
</Codenesium>*/