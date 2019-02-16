using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractDALQuoteTweetMapper
	{
		public virtual QuoteTweet MapModelToEntity(
			int quoteTweetId,
			ApiQuoteTweetServerRequestModel model
			)
		{
			QuoteTweet item = new QuoteTweet();
			item.SetProperties(
				quoteTweetId,
				model.Content,
				model.Date,
				model.RetweeterUserId,
				model.SourceTweetId,
				model.Time);
			return item;
		}

		public virtual ApiQuoteTweetServerResponseModel MapEntityToModel(
			QuoteTweet item)
		{
			var model = new ApiQuoteTweetServerResponseModel();

			model.SetProperties(item.QuoteTweetId,
			                    item.Content,
			                    item.Date,
			                    item.RetweeterUserId,
			                    item.SourceTweetId,
			                    item.Time);
			if (item.RetweeterUserIdNavigation != null)
			{
				var retweeterUserIdModel = new ApiUserServerResponseModel();
				retweeterUserIdModel.SetProperties(
					item.RetweeterUserIdNavigation.UserId,
					item.RetweeterUserIdNavigation.BioImgUrl,
					item.RetweeterUserIdNavigation.Birthday,
					item.RetweeterUserIdNavigation.ContentDescription,
					item.RetweeterUserIdNavigation.Email,
					item.RetweeterUserIdNavigation.FullName,
					item.RetweeterUserIdNavigation.HeaderImgUrl,
					item.RetweeterUserIdNavigation.Interest,
					item.RetweeterUserIdNavigation.LocationLocationId,
					item.RetweeterUserIdNavigation.Password,
					item.RetweeterUserIdNavigation.PhoneNumber,
					item.RetweeterUserIdNavigation.Privacy,
					item.RetweeterUserIdNavigation.Username,
					item.RetweeterUserIdNavigation.Website);

				model.SetRetweeterUserIdNavigation(retweeterUserIdModel);
			}

			if (item.SourceTweetIdNavigation != null)
			{
				var sourceTweetIdModel = new ApiTweetServerResponseModel();
				sourceTweetIdModel.SetProperties(
					item.SourceTweetIdNavigation.TweetId,
					item.SourceTweetIdNavigation.Content,
					item.SourceTweetIdNavigation.Date,
					item.SourceTweetIdNavigation.LocationId,
					item.SourceTweetIdNavigation.Time,
					item.SourceTweetIdNavigation.UserUserId);

				model.SetSourceTweetIdNavigation(sourceTweetIdModel);
			}

			return model;
		}

		public virtual List<ApiQuoteTweetServerResponseModel> MapEntityToModel(
			List<QuoteTweet> items)
		{
			List<ApiQuoteTweetServerResponseModel> response = new List<ApiQuoteTweetServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ced8e1b2be15cb911491763764c9f60d</Hash>
</Codenesium>*/