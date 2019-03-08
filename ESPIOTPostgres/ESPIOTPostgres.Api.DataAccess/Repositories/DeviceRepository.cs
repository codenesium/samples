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
    <Hash>4430c5a5dedefdf259e5599f858a0f89</Hash>
</Codenesium>*/