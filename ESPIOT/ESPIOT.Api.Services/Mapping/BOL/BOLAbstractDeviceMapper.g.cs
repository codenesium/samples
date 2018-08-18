using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public abstract class BOLAbstractDeviceMapper
	{
		public virtual BODevice MapModelToBO(
			int id,
			ApiDeviceRequestModel model
			)
		{
			BODevice boDevice = new BODevice();
			boDevice.SetProperties(
				id,
				model.Name,
				model.PublicId);
			return boDevice;
		}

		public virtual ApiDeviceResponseModel MapBOToModel(
			BODevice boDevice)
		{
			var model = new ApiDeviceResponseModel();

			model.SetProperties(boDevice.Id, boDevice.Name, boDevice.PublicId);

			return model;
		}

		public virtual List<ApiDeviceResponseModel> MapBOToModel(
			List<BODevice> items)
		{
			List<ApiDeviceResponseModel> response = new List<ApiDeviceResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f7e8029db8b008c816ecd7f58e953918</Hash>
</Codenesium>*/