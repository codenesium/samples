using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractDirectTweetMapper
	{
		public virtual BODirectTweet MapModelToBO(
			int tweetId,
			ApiDirectTweetServerRequestModel model
			)
		{
			BODirectTweet boDirectTweet = new BODirectTweet();
			boDirectTweet.SetProperties(
				tweetId,
				model.Content,
				model.Date,
				model.TaggedUserId,
				model.Time);
			return boDirectTweet;
		}

		public virtual ApiDirectTweetServerResponseModel MapBOToModel(
			BODirectTweet boDirectTweet)
		{
			var model = new ApiDirectTweetServerResponseModel();

			model.SetProperties(boDirectTweet.TweetId, boDirectTweet.Content, boDirectTweet.Date, boDirectTweet.TaggedUserId, boDirectTweet.Time);

			return model;
		}

		public virtual List<ApiDirectTweetServerResponseModel> MapBOToModel(
			List<BODirectTweet> items)
		{
			List<ApiDirectTweetServerResponseModel> response = new List<ApiDirectTweetServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e891f84f8a946adc16e4dfd165a8e0a8</Hash>
</Codenesium>*/