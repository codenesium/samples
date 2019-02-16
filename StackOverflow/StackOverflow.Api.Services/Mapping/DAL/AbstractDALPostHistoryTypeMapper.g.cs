using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALPostHistoryTypeMapper
	{
		public virtual PostHistoryType MapModelToEntity(
			int id,
			ApiPostHistoryTypeServerRequestModel model
			)
		{
			PostHistoryType item = new PostHistoryType();
			item.SetProperties(
				id,
				model.RwType);
			return item;
		}

		public virtual ApiPostHistoryTypeServerResponseModel MapEntityToModel(
			PostHistoryType item)
		{
			var model = new ApiPostHistoryTypeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.RwType);

			return model;
		}

		public virtual List<ApiPostHistoryTypeServerResponseModel> MapEntityToModel(
			List<PostHistoryType> items)
		{
			List<ApiPostHistoryTypeServerResponseModel> response = new List<ApiPostHistoryTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>24136d9ab54c5e24d416a62fef0c89bd</Hash>
</Codenesium>*/