using Codenesium.DataConversionExtensions;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>b28ed84ae7215208abacdc0c9ee2a73f</Hash>
</Codenesium>*/