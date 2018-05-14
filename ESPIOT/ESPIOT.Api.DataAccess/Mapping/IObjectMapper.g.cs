using System;
using Microsoft.EntityFrameworkCore;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void DeviceMapModelToEF(
			int id,
			DeviceModel model,
			Device efDevice);

		POCODevice DeviceMapEFToPOCO(
			Device efDevice);

		void DeviceActionMapModelToEF(
			int id,
			DeviceActionModel model,
			DeviceAction efDeviceAction);

		POCODeviceAction DeviceActionMapEFToPOCO(
			DeviceAction efDeviceAction);
	}
}

/*<Codenesium>
    <Hash>8ee90a9f705450be37e03e175d91c65b</Hash>
</Codenesium>*/