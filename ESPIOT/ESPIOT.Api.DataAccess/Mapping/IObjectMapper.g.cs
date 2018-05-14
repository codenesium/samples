using System;
using Microsoft.EntityFrameworkCore;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void DeviceMapModelToEF(
			int id,
			ApiDeviceModel model,
			Device efDevice);

		POCODevice DeviceMapEFToPOCO(
			Device efDevice);

		void DeviceActionMapModelToEF(
			int id,
			ApiDeviceActionModel model,
			DeviceAction efDeviceAction);

		POCODeviceAction DeviceActionMapEFToPOCO(
			DeviceAction efDeviceAction);
	}
}

/*<Codenesium>
    <Hash>553b46aec4ad04727d2dbb17c7b90287</Hash>
</Codenesium>*/