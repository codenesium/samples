using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class LocationService : AbstractLocationService, ILocationService
	{
		public LocationService(
			ILogger<ILocationRepository> logger,
			ILocationRepository locationRepository,
			IApiLocationRequestModelValidator locationModelValidator,
			IBOLLocationMapper bollocationMapper,
			IDALLocationMapper dallocationMapper,
			IBOLProductInventoryMapper bolProductInventoryMapper,
			IDALProductInventoryMapper dalProductInventoryMapper,
			IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper,
			IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper
			)
			: base(logger,
			       locationRepository,
			       locationModelValidator,
			       bollocationMapper,
			       dallocationMapper,
			       bolProductInventoryMapper,
			       dalProductInventoryMapper,
			       bolWorkOrderRoutingMapper,
			       dalWorkOrderRoutingMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8368b45695631c0844ba38ef0c2c3983</Hash>
</Codenesium>*/