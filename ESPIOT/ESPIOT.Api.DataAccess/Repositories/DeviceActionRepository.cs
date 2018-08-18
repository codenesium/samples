using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.DataAccess
{
	public partial class DeviceActionRepository : AbstractDeviceActionRepository, IDeviceActionRepository
	{
		public DeviceActionRepository(
			ILogger<DeviceActionRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>053e1164775b66eda89b1ecc4d067ae5</Hash>
</Codenesium>*/