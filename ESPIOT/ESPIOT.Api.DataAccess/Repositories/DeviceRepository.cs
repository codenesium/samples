using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.DataAccess
{
	public class DeviceRepository: AbstractDeviceRepository, IDeviceRepository
	{
		public DeviceRepository(
			ILogger<DeviceRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>664e27a594e727f5663f3706847bdc65</Hash>
</Codenesium>*/