using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractFollowingMapper
	{
		public virtual BOFollowing MapModelToBO(
			int userId,
			ApiFollowingServerRequestModel model
			)
		{
			BOFollowing boFollowing = new BOFollowing();
			boFollowing.SetProperties(
				userId,
				model.DateFollowed,
				model.Muted);
			return boFollowing;
		}

		public virtual ApiFollowingServerResponseModel MapBOToModel(
			BOFollowing boFollowing)
		{
			var model = new ApiFollowingServerResponseModel();

			model.SetProperties(boFollowing.UserId, boFollowing.DateFollowed, boFollowing.Muted);

			return model;
		}

		public virtual List<ApiFollowingServerResponseModel> MapBOToModel(
			List<BOFollowing> items)
		{
			List<ApiFollowingServerResponseModel> response = new List<ApiFollowingServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>615a2586f7a3e49e733d1d9420ce34e3</Hash>
</Codenesium>*/