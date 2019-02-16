using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractDALDeviceActionMapper
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
    <Hash>df37dd1cf784910b5064762d34dfbad1</Hash>
</Codenesium>*/