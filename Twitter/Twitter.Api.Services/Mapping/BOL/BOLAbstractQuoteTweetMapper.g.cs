using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractQuoteTweetMapper
	{
		public virtual BOQuoteTweet MapModelToBO(
			int quoteTweetId,
			ApiQuoteTweetServerRequestModel model
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

		public virtual ApiQuoteTweetServerResponseModel MapBOToModel(
			BOQuoteTweet boQuoteTweet)
		{
			var model = new ApiQuoteTweetServerResponseModel();

			model.SetProperties(boQuoteTweet.QuoteTweetId, boQuoteTweet.Content, boQuoteTweet.Date, boQuoteTweet.RetweeterUserId, boQuoteTweet.SourceTweetId, boQuoteTweet.Time);

			return model;
		}

		public virtual List<ApiQuoteTweetServerResponseModel> MapBOToModel(
			List<BOQuoteTweet> items)
		{
			List<ApiQuoteTweetServerResponseModel> response = new List<ApiQuoteTweetServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>475c33a1e0ce33ee957fcd68b3c5399e</Hash>
</Codenesium>*/