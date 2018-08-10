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
	public partial class DeviceService : AbstractDeviceService, IDeviceService
	{
		public DeviceService(
			ILogger<IDeviceRepository> logger,
			IDeviceRepository deviceRepository,
			IApiDeviceRequestModelValidator deviceModelValidator,
			IBOLDeviceMapper boldeviceMapper,
			IDALDeviceMapper daldeviceMapper,
			IBOLDeviceActionMapper bolDeviceActionMapper,
			IDALDeviceActionMapper dalDeviceActionMapper
			)
			: base(logger,
			       deviceRepository,
			       deviceModelValidator,
			       boldeviceMapper,
			       daldeviceMapper,
			       bolDeviceActionMapper,
			       dalDeviceActionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0d4c7fd9dd0ae585083568e1cb0b15a5</Hash>
</Codenesium>*/