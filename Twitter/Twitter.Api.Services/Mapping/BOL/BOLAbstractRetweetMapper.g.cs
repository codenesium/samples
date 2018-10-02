using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractRetweetMapper
	{
		public virtual BORetweet MapModelToBO(
			int id,
			ApiRetweetRequestModel model
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

		public virtual ApiRetweetResponseModel MapBOToModel(
			BORetweet boRetweet)
		{
			var model = new ApiRetweetResponseModel();

			model.SetProperties(boRetweet.Id, boRetweet.Date, boRetweet.RetwitterUserId, boRetweet.Time, boRetweet.TweetTweetId);

			return model;
		}

		public virtual List<ApiRetweetResponseModel> MapBOToModel(
			List<BORetweet> items)
		{
			List<ApiRetweetResponseModel> response = new List<ApiRetweetResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0d45999bffc8ca0cb9a50a41f68d8140</Hash>
</Codenesium>*/