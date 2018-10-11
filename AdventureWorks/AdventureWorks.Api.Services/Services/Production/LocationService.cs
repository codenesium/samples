using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
			IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper)
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
    <Hash>0290729a861733194e937cb3e69f3647</Hash>
</Codenesium>*/