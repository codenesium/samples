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

		POCODevice DeviceMapEFToPOCO(
			EFDevice efDevice);

		void DeviceActionMapModelToEF(
			int id,
			DeviceActionModel model,
			EFDeviceAction efDeviceAction);

		POCODeviceAction DeviceActionMapEFToPOCO(
			EFDeviceAction efDeviceAction);
	}
}

/*<Codenesium>
    <Hash>e4bd99235cd532aed049374a8a8cbb4c</Hash>
</Codenesium>*/