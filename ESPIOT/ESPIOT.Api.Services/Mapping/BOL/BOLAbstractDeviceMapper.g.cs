using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public abstract class BOLAbstractDeviceMapper
	{
		public virtual BODevice MapModelToBO(
			int id,
			ApiDeviceServerRequestModel model
			)
		{
			BODevice boDevice = new BODevice();
			boDevice.SetProperties(
				id,
				model.Name,
				model.PublicId);
			return boDevice;
		}

		public virtual ApiDeviceServerResponseModel MapBOToModel(
			BODevice boDevice)
		{
			var model = new ApiDeviceServerResponseModel();

			model.SetProperties(boDevice.Id, boDevice.Name, boDevice.PublicId);

			return model;
		}

		public virtual List<ApiDeviceServerResponseModel> MapBOToModel(
			List<BODevice> items)
		{
			List<ApiDeviceServerResponseModel> response = new List<ApiDeviceServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>152fecdecc130f55ccf14436a555b18d</Hash>
</Codenesium>*/