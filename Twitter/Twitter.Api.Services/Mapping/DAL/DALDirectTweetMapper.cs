using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class DALDirectTweetMapper : IDALDirectTweetMapper
	{
		public virtual DirectTweet MapModelToEntity(
			int tweetId,
			ApiDirectTweetServerRequestModel model
			)
		{
			DirectTweet item = new DirectTweet();
			item.SetProperties(
				tweetId,
				model.Content,
				model.Date,
				model.TaggedUserId,
				model.Time);
			return item;
		}

		public virtual ApiDirectTweetServerResponseModel MapEntityToModel(
			DirectTweet item)
		{
			var model = new ApiDirectTweetServerResponseModel();

			model.SetProperties(item.TweetId,
			                    item.Content,
			                    item.Date,
			                    item.TaggedUserId,
			                    item.Time);
			if (item.TaggedUserIdNavigation != null)
			{
				var taggedUserIdModel = new ApiUserServerResponseModel();
				taggedUserIdModel.SetProperties(
					item.TaggedUserIdNavigation.UserId,
					item.TaggedUserIdNavigation.BioImgUrl,
					item.TaggedUserIdNavigation.Birthday,
					item.TaggedUserIdNavigation.ContentDescription,
					item.TaggedUserIdNavigation.Email,
					item.TaggedUserIdNavigation.FullName,
					item.TaggedUserIdNavigation.HeaderImgUrl,
					item.TaggedUserIdNavigation.Interest,
					item.TaggedUserIdNavigation.LocationLocationId,
					item.TaggedUserIdNavigation.Password,
					item.TaggedUserIdNavigation.PhoneNumber,
					item.TaggedUserIdNavigation.Privacy,
					item.TaggedUserIdNavigation.Username,
					item.TaggedUserIdNavigation.Website);

				model.SetTaggedUserIdNavigation(taggedUserIdModel);
			}

			return model;
		}

		public virtual List<ApiDirectTweetServerResponseModel> MapEntityToModel(
			List<DirectTweet> items)
		{
			List<ApiDirectTweetServerResponseModel> response = new List<ApiDirectTweetServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c2e3bcfce88e13e6e4bd62ada9c125ec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/