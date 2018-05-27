using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.BusinessObjects
{
	public class BODevice: AbstractBODevice, IBODevice
	{
		public BODevice(
			ILogger<DeviceRepository> logger,
			IDeviceRepository deviceRepository,
			IApiDeviceRequestModelValidator deviceModelValidator,
			IBOLDeviceMapper deviceMapper)
			: base(logger, deviceRepository, deviceModelValidator, deviceMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>1bbedfb9ac5d8821d2a699f14ccb4d0a</Hash>
</Codenesium>*/