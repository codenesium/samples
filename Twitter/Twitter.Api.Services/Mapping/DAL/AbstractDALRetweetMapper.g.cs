using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractDALRetweetMapper
	{
		public virtual Retweet MapModelToEntity(
			int id,
			ApiRetweetServerRequestModel model
			)
		{
			Retweet item = new Retweet();
			item.SetProperties(
				id,
				model.Date,
				model.RetwitterUserId,
				model.Time,
				model.TweetTweetId);
			return item;
		}

		public virtual ApiRetweetServerResponseModel MapEntityToModel(
			Retweet item)
		{
			var model = new ApiRetweetServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Date,
			                    item.RetwitterUserId,
			                    item.Time,
			                    item.TweetTweetId);
			if (item.RetwitterUserIdNavigation != null)
			{
				var retwitterUserIdModel = new ApiUserServerResponseModel();
				retwitterUserIdModel.SetProperties(
					item.RetwitterUserIdNavigation.UserId,
					item.RetwitterUserIdNavigation.BioImgUrl,
					item.RetwitterUserIdNavigation.Birthday,
					item.RetwitterUserIdNavigation.ContentDescription,
					item.RetwitterUserIdNavigation.Email,
					item.RetwitterUserIdNavigation.FullName,
					item.RetwitterUserIdNavigation.HeaderImgUrl,
					item.RetwitterUserIdNavigation.Interest,
					item.RetwitterUserIdNavigation.LocationLocationId,
					item.RetwitterUserIdNavigation.Password,
					item.RetwitterUserIdNavigation.PhoneNumber,
					item.RetwitterUserIdNavigation.Privacy,
					item.RetwitterUserIdNavigation.Username,
					item.RetwitterUserIdNavigation.Website);

				model.SetRetwitterUserIdNavigation(retwitterUserIdModel);
			}

			if (item.TweetTweetIdNavigation != null)
			{
				var tweetTweetIdModel = new ApiTweetServerResponseModel();
				tweetTweetIdModel.SetProperties(
					item.TweetTweetIdNavigation.TweetId,
					item.TweetTweetIdNavigation.Content,
					item.TweetTweetIdNavigation.Date,
					item.TweetTweetIdNavigation.LocationId,
					item.TweetTweetIdNavigation.Time,
					item.TweetTweetIdNavigation.UserUserId);

				model.SetTweetTweetIdNavigation(tweetTweetIdModel);
			}

			return model;
		}

		public virtual List<ApiRetweetServerResponseModel> MapEntityToModel(
			List<Retweet> items)
		{
			List<ApiRetweetServerResponseModel> response = new List<ApiRetweetServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7cabf33caf4cb06662977250b187e949</Hash>
</Codenesium>*/