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
			EFDevice efDevice);

		void DeviceMapEFToPOCO(
			EFDevice efDevice,
			ApiResponse response);

		void DeviceActionMapModelToEF(
			int id,
			DeviceActionModel model,
			EFDeviceAction efDeviceAction);

		void DeviceActionMapEFToPOCO(
			EFDeviceAction efDeviceAction,
			ApiResponse response);
	}
}

/*<Codenesium>
    <Hash>0e96321612881c47701b6a0b29767363</Hash>
</Codenesium>*/