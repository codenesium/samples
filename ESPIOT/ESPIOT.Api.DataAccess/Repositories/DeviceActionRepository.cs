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
    <Hash>9237bf979107a7d1dc8ef860150bd26e</Hash>
</Codenesium>*/