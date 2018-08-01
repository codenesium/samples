using Codenesium.DataConversionExtensions;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Services
{
	public partial class DeviceActionService : AbstractDeviceActionService, IDeviceActionService
	{
		public DeviceActionService(
			ILogger<IDeviceActionRepository> logger,
			IDeviceActionRepository deviceActionRepository,
			IApiDeviceActionRequestModelValidator deviceActionModelValidator,
			IBOLDeviceActionMapper boldeviceActionMapper,
			IDALDeviceActionMapper daldeviceActionMapper
			)
			: base(logger,
			       deviceActionRepository,
			       deviceActionModelValidator,
			       boldeviceActionMapper,
			       daldeviceActionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e85e0f4621c2ae2317e17b8d30eba2a0</Hash>
</Codenesium>*/