using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractFollowerMapper
	{
		public virtual BOFollower MapModelToBO(
			int id,
			ApiFollowerServerRequestModel model
			)
		{
			BOFollower boFollower = new BOFollower();
			boFollower.SetProperties(
				id,
				model.Blocked,
				model.DateFollowed,
				model.FollowedUserId,
				model.FollowingUserId,
				model.FollowRequestStatu,
				model.Muted);
			return boFollower;
		}

		public virtual ApiFollowerServerResponseModel MapBOToModel(
			BOFollower boFollower)
		{
			var model = new ApiFollowerServerResponseModel();

			model.SetProperties(boFollower.Id, boFollower.Blocked, boFollower.DateFollowed, boFollower.FollowedUserId, boFollower.FollowingUserId, boFollower.FollowRequestStatu, boFollower.Muted);

			return model;
		}

		public virtual List<ApiFollowerServerResponseModel> MapBOToModel(
			List<BOFollower> items)
		{
			List<ApiFollowerServerResponseModel> response = new List<ApiFollowerServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5bcb6d2b2bd7c1d30850371946ebae28</Hash>
</Codenesium>*/