using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>0305ab334cf2f8c7609c4b2884088f77</Hash>
</Codenesium>*/