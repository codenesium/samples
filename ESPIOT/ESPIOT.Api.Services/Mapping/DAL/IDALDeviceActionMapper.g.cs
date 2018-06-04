using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.Services
{
	public interface IDALDeviceActionMapper
	{
		DeviceAction MapBOToEF(
			BODeviceAction bo);

		BODeviceAction MapEFToBO(
			DeviceAction efDeviceAction);

		List<BODeviceAction> MapEFToBO(
			List<DeviceAction> records);
	}
}

/*<Codenesium>
    <Hash>9d1e690ec8e6c4b466a5e5e38c639248</Hash>
</Codenesium>*/