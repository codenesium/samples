using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public partial interface IDALDeviceActionMapper
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
    <Hash>104372b5b8c3ded17401dc7c58166690</Hash>
</Codenesium>*/