using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractTweetMapper
	{
		public virtual BOTweet MapModelToBO(
			int tweetId,
			ApiTweetRequestModel model
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

		public virtual ApiTweetResponseModel MapBOToModel(
			BOTweet boTweet)
		{
			var model = new ApiTweetResponseModel();

			model.SetProperties(boTweet.TweetId, boTweet.Content, boTweet.Date, boTweet.LocationId, boTweet.Time, boTweet.UserUserId);

			return model;
		}

		public virtual List<ApiTweetResponseModel> MapBOToModel(
			List<BOTweet> items)
		{
			List<ApiTweetResponseModel> response = new List<ApiTweetResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ef27bd885e896084161d877275e12f0f</Hash>
</Codenesium>*/