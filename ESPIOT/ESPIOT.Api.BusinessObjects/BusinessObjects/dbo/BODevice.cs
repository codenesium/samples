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
			IDeviceModelValidator deviceModelValidator)
			: base(logger, deviceRepository, deviceModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>3a11d1756e7dd54495b58e3cfb6ddefc</Hash>
</Codenesium>*/