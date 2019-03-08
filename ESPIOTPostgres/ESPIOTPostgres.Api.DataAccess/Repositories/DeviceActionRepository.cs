using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.DataAccess
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
    <Hash>ffc3135a79d34898672ce9bb50c736cf</Hash>
</Codenesium>*/