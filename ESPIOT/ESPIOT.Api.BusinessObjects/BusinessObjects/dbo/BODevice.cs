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
			IApiDeviceModelValidator deviceModelValidator)
			: base(logger, deviceRepository, deviceModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>783f7c57490d16d62e0af5e195fcd333</Hash>
</Codenesium>*/