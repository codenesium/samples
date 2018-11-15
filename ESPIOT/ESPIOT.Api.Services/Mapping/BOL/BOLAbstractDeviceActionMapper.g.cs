using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public abstract class BOLAbstractDeviceActionMapper
	{
		public virtual BODeviceAction MapModelToBO(
			int id,
			ApiDeviceActionServerRequestModel model
			)
		{
			BODeviceAction boDeviceAction = new BODeviceAction();
			boDeviceAction.SetProperties(
				id,
				model.@Value,
				model.DeviceId,
				model.Name);
			return boDeviceAction;
		}

		public virtual ApiDeviceActionServerResponseModel MapBOToModel(
			BODeviceAction boDeviceAction)
		{
			var model = new ApiDeviceActionServerResponseModel();

			model.SetProperties(boDeviceAction.Id, boDeviceAction.@Value, boDeviceAction.DeviceId, boDeviceAction.Name);

			return model;
		}

		public virtual List<ApiDeviceActionServerResponseModel> MapBOToModel(
			List<BODeviceAction> items)
		{
			List<ApiDeviceActionServerResponseModel> response = new List<ApiDeviceActionServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>75d0b55e120adeb2308c9742c2f15af5</Hash>
</Codenesium>*/