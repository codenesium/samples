using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALDirectTweetMapper
	{
		DirectTweet MapModelToEntity(
			int tweetId,
			ApiDirectTweetServerRequestModel model);

		ApiDirectTweetServerResponseModel MapEntityToModel(
			DirectTweet item);

		List<ApiDirectTweetServerResponseModel> MapEntityToModel(
			List<DirectTweet> items);
	}
}

/*<Codenesium>
    <Hash>10e3b6363672ac75873249180d39f660</Hash>
</Codenesium>*/