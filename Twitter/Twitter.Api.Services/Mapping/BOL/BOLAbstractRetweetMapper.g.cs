using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractRetweetMapper
	{
		public virtual BORetweet MapModelToBO(
			int id,
			ApiRetweetServerRequestModel model
			)
		{
			BORetweet boRetweet = new BORetweet();
			boRetweet.SetProperties(
				id,
				model.Date,
				model.RetwitterUserId,
				model.Time,
				model.TweetTweetId);
			return boRetweet;
		}

		public virtual ApiRetweetServerResponseModel MapBOToModel(
			BORetweet boRetweet)
		{
			var model = new ApiRetweetServerResponseModel();

			model.SetProperties(boRetweet.Id, boRetweet.Date, boRetweet.RetwitterUserId, boRetweet.Time, boRetweet.TweetTweetId);

			return model;
		}

		public virtual List<ApiRetweetServerResponseModel> MapBOToModel(
			List<BORetweet> items)
		{
			List<ApiRetweetServerResponseModel> response = new List<ApiRetweetServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4c80120784151ab05aea19339e796234</Hash>
</Codenesium>*/