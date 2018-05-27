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
	public class DeviceActionRepository: AbstractDeviceActionRepository, IDeviceActionRepository
	{
		public DeviceActionRepository(
			IDALDeviceActionMapper mapper,
			ILogger<DeviceActionRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>13f01586ede18db061a714aab979ed7e</Hash>
</Codenesium>*/