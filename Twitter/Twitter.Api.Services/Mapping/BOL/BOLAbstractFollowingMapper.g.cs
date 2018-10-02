using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractFollowingMapper
	{
		public virtual BOFollowing MapModelToBO(
			string userId,
			ApiFollowingRequestModel model
			)
		{
			BOFollowing boFollowing = new BOFollowing();
			boFollowing.SetProperties(
				userId,
				model.DateFollowed,
				model.Muted);
			return boFollowing;
		}

		public virtual ApiFollowingResponseModel MapBOToModel(
			BOFollowing boFollowing)
		{
			var model = new ApiFollowingResponseModel();

			model.SetProperties(boFollowing.UserId, boFollowing.DateFollowed, boFollowing.Muted);

			return model;
		}

		public virtual List<ApiFollowingResponseModel> MapBOToModel(
			List<BOFollowing> items)
		{
			List<ApiFollowingResponseModel> response = new List<ApiFollowingResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7e2f4440bd3e79212e5dddf12cf448f7</Hash>
</Codenesium>*/