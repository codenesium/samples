using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>a3169450225109542b6daa0255ebfc3c</Hash>
</Codenesium>*/