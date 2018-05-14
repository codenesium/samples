using System;
using Microsoft.EntityFrameworkCore;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.DataAccess
{
	public abstract class AbstractObjectMapper
	{
		public virtual void DeviceMapModelToEF(
			int id,
			ApiDeviceModel model,
			Device efDevice)
		{
			efDevice.SetProperties(
				id,
				model.Name,
				model.PublicId);
		}

		public virtual POCODevice DeviceMapEFToPOCO(
			Device efDevice)
		{
			if (efDevice == null)
			{
				return null;
			}

			return new POCODevice(efDevice.Id, efDevice.Name, efDevice.PublicId);
		}

		public virtual void DeviceActionMapModelToEF(
			int id,
			ApiDeviceActionModel model,
			DeviceAction efDeviceAction)
		{
			efDeviceAction.SetProperties(
				id,
				model.DeviceId,
				model.Name,
				model.@Value);
		}

		public virtual POCODeviceAction DeviceActionMapEFToPOCO(
			DeviceAction efDeviceAction)
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
    <Hash>cc61321b53b089fc7f2022b85154d21f</Hash>
</Codenesium>*/