using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractDALFollowingMapper
	{
		public virtual Following MapModelToEntity(
			int userId,
			ApiFollowingServerRequestModel model
			)
		{
			Following item = new Following();
			item.SetProperties(
				userId,
				model.DateFollowed,
				model.Muted);
			return item;
		}

		public virtual ApiFollowingServerResponseModel MapEntityToModel(
			Following item)
		{
			var model = new ApiFollowingServerResponseModel();

			model.SetProperties(item.UserId,
			                    item.DateFollowed,
			                    item.Muted);

			return model;
		}

		public virtual List<ApiFollowingServerResponseModel> MapEntityToModel(
			List<Following> items)
		{
			List<ApiFollowingServerResponseModel> response = new List<ApiFollowingServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fff0d51712706fedce6d14b4790bbb64</Hash>
</Codenesium>*/