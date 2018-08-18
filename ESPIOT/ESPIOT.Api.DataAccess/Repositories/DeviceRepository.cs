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
    <Hash>241dca3d2811b00a13b69974d2862848</Hash>
</Codenesium>*/