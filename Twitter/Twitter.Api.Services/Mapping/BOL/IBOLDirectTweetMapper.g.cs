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
			ApiDirectTweetServerRequestModel model);

		ApiDirectTweetServerResponseModel MapBOToModel(
			BODirectTweet boDirectTweet);

		List<ApiDirectTweetServerResponseModel> MapBOToModel(
			List<BODirectTweet> items);
	}
}

/*<Codenesium>
    <Hash>f208f452bed4228a81531f5c3251ad86</Hash>
</Codenesium>*/