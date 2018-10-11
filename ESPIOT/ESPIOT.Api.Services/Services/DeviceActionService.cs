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
			IDALDeviceActionMapper daldeviceActionMapper)
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
    <Hash>3c8620c3295bf8dffe07bf3e48ba5ae1</Hash>
</Codenesium>*/