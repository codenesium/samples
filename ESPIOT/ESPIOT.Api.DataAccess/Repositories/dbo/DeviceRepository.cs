using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public class DeviceRepository: AbstractDeviceRepository, IDeviceRepository
	{
		public DeviceRepository(
			IDALDeviceMapper mapper,
			ILogger<DeviceRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>7b0a4526bd3164e3d777fc09f9f753a1</Hash>
</Codenesium>*/