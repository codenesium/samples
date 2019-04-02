using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALEventStatusMapper
	{
		public virtual EventStatus MapModelToEntity(
			int id,
			ApiEventStatusServerRequestModel model
			)
		{
			EventStatus item = new EventStatus();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiEventStatusServerResponseModel MapEntityToModel(
			EventStatus item)
		{
			var model = new ApiEventStatusServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiEventStatusServerResponseModel> MapEntityToModel(
			List<EventStatus> items)
		{
			List<ApiEventStatusServerResponseModel> response = new List<ApiEventStatusServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ca2e50c939648716a363068e4273ca3a</Hash>
</Codenesium>*/