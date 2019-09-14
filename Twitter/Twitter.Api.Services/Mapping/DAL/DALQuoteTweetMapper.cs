using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class DALQuoteTweetMapper : IDALQuoteTweetMapper
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
    <Hash>f18fef38349ec07ae399083d8519b7c4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/