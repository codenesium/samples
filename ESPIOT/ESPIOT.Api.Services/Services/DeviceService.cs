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
	public class DeviceService: AbstractDeviceService, IDeviceService
	{
		public DeviceService(
			ILogger<DeviceRepository> logger,
			IDeviceRepository deviceRepository,
			IApiDeviceRequestModelValidator deviceModelValidator,
			IBOLDeviceMapper BOLdeviceMapper,
			IDALDeviceMapper DALdeviceMapper)
			: base(logger, deviceRepository,
			       deviceModelValidator,
			       BOLdeviceMapper,
			       DALdeviceMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>b8a6c0455e689f887cf1e332be25778c</Hash>
</Codenesium>*/