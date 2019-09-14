using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class DALEventStatusMapper : IDALEventStatusMapper
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
    <Hash>1b415f5dc3d7b651b29e4175c9f5a8ea</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/