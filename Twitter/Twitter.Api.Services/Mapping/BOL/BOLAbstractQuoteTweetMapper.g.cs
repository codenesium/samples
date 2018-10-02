using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractQuoteTweetMapper
	{
		public virtual BOQuoteTweet MapModelToBO(
			int quoteTweetId,
			ApiQuoteTweetRequestModel model
			)
		{
			BOQuoteTweet boQuoteTweet = new BOQuoteTweet();
			boQuoteTweet.SetProperties(
				quoteTweetId,
				model.Content,
				model.Date,
				model.RetweeterUserId,
				model.SourceTweetId,
				model.Time);
			return boQuoteTweet;
		}

		public virtual ApiQuoteTweetResponseModel MapBOToModel(
			BOQuoteTweet boQuoteTweet)
		{
			var model = new ApiQuoteTweetResponseModel();

			model.SetProperties(boQuoteTweet.QuoteTweetId, boQuoteTweet.Content, boQuoteTweet.Date, boQuoteTweet.RetweeterUserId, boQuoteTweet.SourceTweetId, boQuoteTweet.Time);

			return model;
		}

		public virtual List<ApiQuoteTweetResponseModel> MapBOToModel(
			List<BOQuoteTweet> items)
		{
			List<ApiQuoteTweetResponseModel> response = new List<ApiQuoteTweetResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fa5db6f1ec3d1521b88e27992019b62a</Hash>
</Codenesium>*/