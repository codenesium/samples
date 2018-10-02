using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractLikeMapper
	{
		public virtual BOLike MapModelToBO(
			int likeId,
			ApiLikeRequestModel model
			)
		{
			BOLike boLike = new BOLike();
			boLike.SetProperties(
				likeId,
				model.LikerUserId,
				model.TweetId);
			return boLike;
		}

		public virtual ApiLikeResponseModel MapBOToModel(
			BOLike boLike)
		{
			var model = new ApiLikeResponseModel();

			model.SetProperties(boLike.LikeId, boLike.LikerUserId, boLike.TweetId);

			return model;
		}

		public virtual List<ApiLikeResponseModel> MapBOToModel(
			List<BOLike> items)
		{
			List<ApiLikeResponseModel> response = new List<ApiLikeResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b71b841c8222ac9a63a820022635495c</Hash>
</Codenesium>*/