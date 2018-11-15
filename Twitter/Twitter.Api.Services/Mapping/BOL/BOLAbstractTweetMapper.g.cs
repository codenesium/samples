using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractTweetMapper
	{
		public virtual BOTweet MapModelToBO(
			int tweetId,
			ApiTweetServerRequestModel model
			)
		{
			BOTweet boTweet = new BOTweet();
			boTweet.SetProperties(
				tweetId,
				model.Content,
				model.Date,
				model.LocationId,
				model.Time,
				model.UserUserId);
			return boTweet;
		}

		public virtual ApiTweetServerResponseModel MapBOToModel(
			BOTweet boTweet)
		{
			var model = new ApiTweetServerResponseModel();

			model.SetProperties(boTweet.TweetId, boTweet.Content, boTweet.Date, boTweet.LocationId, boTweet.Time, boTweet.UserUserId);

			return model;
		}

		public virtual List<ApiTweetServerResponseModel> MapBOToModel(
			List<BOTweet> items)
		{
			List<ApiTweetServerResponseModel> response = new List<ApiTweetServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>736a92479448dc26919f4c42c606796a</Hash>
</Codenesium>*/