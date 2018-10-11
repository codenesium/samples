using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractFollowerMapper
	{
		public virtual BOFollower MapModelToBO(
			int id,
			ApiFollowerRequestModel model
			)
		{
			BOFollower boFollower = new BOFollower();
			boFollower.SetProperties(
				id,
				model.Blocked,
				model.DateFollowed,
				model.FollowRequestStatu,
				model.FollowedUserId,
				model.FollowingUserId,
				model.Muted);
			return boFollower;
		}

		public virtual ApiFollowerResponseModel MapBOToModel(
			BOFollower boFollower)
		{
			var model = new ApiFollowerResponseModel();

			model.SetProperties(boFollower.Id, boFollower.Blocked, boFollower.DateFollowed, boFollower.FollowRequestStatu, boFollower.FollowedUserId, boFollower.FollowingUserId, boFollower.Muted);

			return model;
		}

		public virtual List<ApiFollowerResponseModel> MapBOToModel(
			List<BOFollower> items)
		{
			List<ApiFollowerResponseModel> response = new List<ApiFollowerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>387f7a7d867f6458e8aef119b4c73919</Hash>
</Codenesium>*/