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
				model.Type);
			return item;
		}

		public virtual ApiPostHistoryTypeServerResponseModel MapEntityToModel(
			PostHistoryType item)
		{
			var model = new ApiPostHistoryTypeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Type);

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
    <Hash>540ef1e29ea956f0acdca303b853b40c</Hash>
</Codenesium>*/