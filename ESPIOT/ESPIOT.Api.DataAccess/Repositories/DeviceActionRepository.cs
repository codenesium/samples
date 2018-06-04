using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.DataAccess
{
	public class DeviceActionRepository: AbstractDeviceActionRepository, IDeviceActionRepository
	{
		public DeviceActionRepository(
			ILogger<DeviceActionRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>80470ed72a19551cdfd7337d4201ad02</Hash>
</Codenesium>*/