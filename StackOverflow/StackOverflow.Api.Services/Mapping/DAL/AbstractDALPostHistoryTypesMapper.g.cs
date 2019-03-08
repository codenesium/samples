using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALPostHistoryTypesMapper
	{
		public virtual PostHistoryTypes MapModelToEntity(
			int id,
			ApiPostHistoryTypesServerRequestModel model
			)
		{
			PostHistoryTypes item = new PostHistoryTypes();
			item.SetProperties(
				id,
				model.RwType);
			return item;
		}

		public virtual ApiPostHistoryTypesServerResponseModel MapEntityToModel(
			PostHistoryTypes item)
		{
			var model = new ApiPostHistoryTypesServerResponseModel();

			model.SetProperties(item.Id,
			                    item.RwType);

			return model;
		}

		public virtual List<ApiPostHistoryTypesServerResponseModel> MapEntityToModel(
			List<PostHistoryTypes> items)
		{
			List<ApiPostHistoryTypesServerResponseModel> response = new List<ApiPostHistoryTypesServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bc9dbcf3e1eb3d8000cd56f8238b18a1</Hash>
</Codenesium>*/