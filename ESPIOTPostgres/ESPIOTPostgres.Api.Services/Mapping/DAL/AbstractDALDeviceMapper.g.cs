using ESPIOTPostgresNS.Api.Contracts;
using ESPIOTPostgresNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTPostgresNS.Api.Services
{
	public abstract class AbstractDALDeviceMapper
	{
		public virtual Device MapModelToEntity(
			int id,
			ApiDeviceServerRequestModel model
			)
		{
			Device item = new Device();
			item.SetProperties(
				id,
				model.Name,
				model.PublicId);
			return item;
		}

		public virtual ApiDeviceServerResponseModel MapEntityToModel(
			Device item)
		{
			var model = new ApiDeviceServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name,
			                    item.PublicId);

			return model;
		}

		public virtual List<ApiDeviceServerResponseModel> MapEntityToModel(
			List<Device> items)
		{
			List<ApiDeviceServerResponseModel> response = new List<ApiDeviceServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>351ad9a3f2521b2a981511d2a372d67a</Hash>
</Codenesium>*/