using System;
using Microsoft.EntityFrameworkCore;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.DataAccess
{
	public abstract class AbstractObjectMapper
	{
		public virtual void DeviceMapModelToEF(
			int id,
			DeviceModel model,
			EFDevice efDevice)
		{
			efDevice.SetProperties(
				id,
				model.PublicId,
				model.Name);
		}

		public virtual void DeviceMapEFToPOCO(
			EFDevice efDevice,
			ApiResponse response)
		{
			if (efDevice == null)
			{
				return;
			}

			response.AddDevice(new POCODevice(efDevice.Id, efDevice.PublicId, efDevice.Name));
		}

		public virtual void DeviceActionMapModelToEF(
			int id,
			DeviceActionModel model,
			EFDeviceAction efDeviceAction)
		{
			efDeviceAction.SetProperties(
				id,
				model.DeviceId,
				model.Name,
				model.@Value);
		}

		public virtual void DeviceActionMapEFToPOCO(
			EFDeviceAction efDeviceAction,
			ApiResponse response)
		{
			if (efDeviceAction == null)
			{
				return;
			}

			response.AddDeviceAction(new POCODeviceAction(efDeviceAction.Id, efDeviceAction.DeviceId, efDeviceAction.Name, efDeviceAction.@Value));

			this.DeviceMapEFToPOCO(efDeviceAction.Device, response);
		}
	}
}

/*<Codenesium>
    <Hash>d70a388057992ffd884a79b37d31934d</Hash>
</Codenesium>*/