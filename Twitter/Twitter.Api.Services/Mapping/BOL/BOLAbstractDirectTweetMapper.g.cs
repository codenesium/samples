using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractDirectTweetMapper
	{
		public virtual BODirectTweet MapModelToBO(
			int tweetId,
			ApiDirectTweetRequestModel model
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

		public virtual ApiDirectTweetResponseModel MapBOToModel(
			BODirectTweet boDirectTweet)
		{
			var model = new ApiDirectTweetResponseModel();

			model.SetProperties(boDirectTweet.TweetId, boDirectTweet.Content, boDirectTweet.Date, boDirectTweet.TaggedUserId, boDirectTweet.Time);

			return model;
		}

		public virtual List<ApiDirectTweetResponseModel> MapBOToModel(
			List<BODirectTweet> items)
		{
			List<ApiDirectTweetResponseModel> response = new List<ApiDirectTweetResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2bc44c2590e0325cf19901229f325aa5</Hash>
</Codenesium>*/