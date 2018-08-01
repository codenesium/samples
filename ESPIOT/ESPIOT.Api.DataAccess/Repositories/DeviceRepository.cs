using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.DataAccess
{
	public partial class DeviceRepository : AbstractDeviceRepository, IDeviceRepository
	{
		public DeviceRepository(
			ILogger<DeviceRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>54a031c1ac36d20fad7684a2498754cf</Hash>
</Codenesium>*/