using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class DALTweetMapper : IDALTweetMapper
	{
		public virtual Tweet MapModelToEntity(
			int tweetId,
			ApiTweetServerRequestModel model
			)
		{
			Tweet item = new Tweet();
			item.SetProperties(
				tweetId,
				model.Content,
				model.Date,
				model.LocationId,
				model.Time,
				model.UserUserId);
			return item;
		}

		public virtual ApiTweetServerResponseModel MapEntityToModel(
			Tweet item)
		{
			var model = new ApiTweetServerResponseModel();

			model.SetProperties(item.TweetId,
			                    item.Content,
			                    item.Date,
			                    item.LocationId,
			                    item.Time,
			                    item.UserUserId);
			if (item.LocationIdNavigation != null)
			{
				var locationIdModel = new ApiLocationServerResponseModel();
				locationIdModel.SetProperties(
					item.LocationIdNavigation.LocationId,
					item.LocationIdNavigation.GpsLat,
					item.LocationIdNavigation.GpsLong,
					item.LocationIdNavigation.LocationName);

				model.SetLocationIdNavigation(locationIdModel);
			}

			if (item.UserUserIdNavigation != null)
			{
				var userUserIdModel = new ApiUserServerResponseModel();
				userUserIdModel.SetProperties(
					item.UserUserIdNavigation.UserId,
					item.UserUserIdNavigation.BioImgUrl,
					item.UserUserIdNavigation.Birthday,
					item.UserUserIdNavigation.ContentDescription,
					item.UserUserIdNavigation.Email,
					item.UserUserIdNavigation.FullName,
					item.UserUserIdNavigation.HeaderImgUrl,
					item.UserUserIdNavigation.Interest,
					item.UserUserIdNavigation.LocationLocationId,
					item.UserUserIdNavigation.Password,
					item.UserUserIdNavigation.PhoneNumber,
					item.UserUserIdNavigation.Privacy,
					item.UserUserIdNavigation.Username,
					item.UserUserIdNavigation.Website);

				model.SetUserUserIdNavigation(userUserIdModel);
			}

			return model;
		}

		public virtual List<ApiTweetServerResponseModel> MapEntityToModel(
			List<Tweet> items)
		{
			List<ApiTweetServerResponseModel> response = new List<ApiTweetServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>92bd175690cf21552a8984d8a929bbd2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/