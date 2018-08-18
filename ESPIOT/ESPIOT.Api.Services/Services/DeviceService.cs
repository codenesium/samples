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
    <Hash>1a81d41295e5a0ec3edb6ee9f93a5e1f</Hash>
</Codenesium>*/