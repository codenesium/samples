using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class DALFollowerMapper : IDALFollowerMapper
	{
		public virtual Follower MapModelToEntity(
			int id,
			ApiFollowerServerRequestModel model
			)
		{
			Follower item = new Follower();
			item.SetProperties(
				id,
				model.Blocked,
				model.DateFollowed,
				model.FollowedUserId,
				model.FollowingUserId,
				model.FollowRequestStatu,
				model.Muted);
			return item;
		}

		public virtual ApiFollowerServerResponseModel MapEntityToModel(
			Follower item)
		{
			var model = new ApiFollowerServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Blocked,
			                    item.DateFollowed,
			                    item.FollowedUserId,
			                    item.FollowingUserId,
			                    item.FollowRequestStatu,
			                    item.Muted);
			if (item.FollowedUserIdNavigation != null)
			{
				var followedUserIdModel = new ApiUserServerResponseModel();
				followedUserIdModel.SetProperties(
					item.FollowedUserIdNavigation.UserId,
					item.FollowedUserIdNavigation.BioImgUrl,
					item.FollowedUserIdNavigation.Birthday,
					item.FollowedUserIdNavigation.ContentDescription,
					item.FollowedUserIdNavigation.Email,
					item.FollowedUserIdNavigation.FullName,
					item.FollowedUserIdNavigation.HeaderImgUrl,
					item.FollowedUserIdNavigation.Interest,
					item.FollowedUserIdNavigation.LocationLocationId,
					item.FollowedUserIdNavigation.Password,
					item.FollowedUserIdNavigation.PhoneNumber,
					item.FollowedUserIdNavigation.Privacy,
					item.FollowedUserIdNavigation.Username,
					item.FollowedUserIdNavigation.Website);

				model.SetFollowedUserIdNavigation(followedUserIdModel);
			}

			if (item.FollowingUserIdNavigation != null)
			{
				var followingUserIdModel = new ApiUserServerResponseModel();
				followingUserIdModel.SetProperties(
					item.FollowingUserIdNavigation.UserId,
					item.FollowingUserIdNavigation.BioImgUrl,
					item.FollowingUserIdNavigation.Birthday,
					item.FollowingUserIdNavigation.ContentDescription,
					item.FollowingUserIdNavigation.Email,
					item.FollowingUserIdNavigation.FullName,
					item.FollowingUserIdNavigation.HeaderImgUrl,
					item.FollowingUserIdNavigation.Interest,
					item.FollowingUserIdNavigation.LocationLocationId,
					item.FollowingUserIdNavigation.Password,
					item.FollowingUserIdNavigation.PhoneNumber,
					item.FollowingUserIdNavigation.Privacy,
					item.FollowingUserIdNavigation.Username,
					item.FollowingUserIdNavigation.Website);

				model.SetFollowingUserIdNavigation(followingUserIdModel);
			}

			return model;
		}

		public virtual List<ApiFollowerServerResponseModel> MapEntityToModel(
			List<Follower> items)
		{
			List<ApiFollowerServerResponseModel> response = new List<ApiFollowerServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6d75c56f6c3aa67dd0eec5cb33362f92</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/