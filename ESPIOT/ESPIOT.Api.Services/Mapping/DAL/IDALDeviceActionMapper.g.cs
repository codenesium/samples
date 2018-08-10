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
    <Hash>ab051c6a01cea25124972d3b7785e44f</Hash>
</Codenesium>*/