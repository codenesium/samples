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
				model.Name,
				model.PublicId);
		}

		public virtual POCODevice DeviceMapEFToPOCO(
			EFDevice efDevice)
		{
			if (efDevice == null)
			{
				return null;
			}

			return new POCODevice(efDevice.Id, efDevice.Name, efDevice.PublicId);
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

		public virtual POCODeviceAction DeviceActionMapEFToPOCO(
			EFDeviceAction efDeviceAction)
		{
			if (efDeviceAction == null)
			{
				return null;
			}

			return new POCODeviceAction(efDeviceAction.DeviceId, efDeviceAction.Id, efDeviceAction.Name, efDeviceAction.@Value);
		}
	}
}

/*<Codenesium>
    <Hash>ed4648a720d4da1fd5fddd63184302db</Hash>
</Codenesium>*/