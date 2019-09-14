using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public class DALDeviceActionMapper : IDALDeviceActionMapper
	{
		public virtual DeviceAction MapModelToEntity(
			int id,
			ApiDeviceActionServerRequestModel model
			)
		{
			DeviceAction item = new DeviceAction();
			item.SetProperties(
				id,
				model.Action,
				model.DeviceId,
				model.Name);
			return item;
		}

		public virtual ApiDeviceActionServerResponseModel MapEntityToModel(
			DeviceAction item)
		{
			var model = new ApiDeviceActionServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Action,
			                    item.DeviceId,
			                    item.Name);
			if (item.DeviceIdNavigation != null)
			{
				var deviceIdModel = new ApiDeviceServerResponseModel();
				deviceIdModel.SetProperties(
					item.DeviceIdNavigation.Id,
					item.DeviceIdNavigation.DateOfLastPing,
					item.DeviceIdNavigation.IsActive,
					item.DeviceIdNavigation.Name,
					item.DeviceIdNavigation.PublicId);

				model.SetDeviceIdNavigation(deviceIdModel);
			}

			return model;
		}

		public virtual List<ApiDeviceActionServerResponseModel> MapEntityToModel(
			List<DeviceAction> items)
		{
			List<ApiDeviceActionServerResponseModel> response = new List<ApiDeviceActionServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2245711fa61d8de4d17c700411143b0d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/