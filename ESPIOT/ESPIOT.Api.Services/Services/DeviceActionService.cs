using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Services
{
	public class DeviceActionService: AbstractDeviceActionService, IDeviceActionService
	{
		public DeviceActionService(
			ILogger<DeviceActionRepository> logger,
			IDeviceActionRepository deviceActionRepository,
			IApiDeviceActionRequestModelValidator deviceActionModelValidator,
			IBOLDeviceActionMapper BOLdeviceActionMapper,
			IDALDeviceActionMapper DALdeviceActionMapper)
			: base(logger, deviceActionRepository,
			       deviceActionModelValidator,
			       BOLdeviceActionMapper,
			       DALdeviceActionMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>6c7544da0b4447e07fcac1f451c0be50</Hash>
</Codenesium>*/