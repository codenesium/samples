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
			ApiTweetServerRequestModel model);

		ApiTweetServerResponseModel MapBOToModel(
			BOTweet boTweet);

		List<ApiTweetServerResponseModel> MapBOToModel(
			List<BOTweet> items);
	}
}

/*<Codenesium>
    <Hash>95fcd7738384ff4e0cca0b4a488dc615</Hash>
</Codenesium>*/