using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class LocationService: AbstractLocationService, ILocationService
	{
		public LocationService(
			ILogger<LocationRepository> logger,
			ILocationRepository locationRepository,
			IApiLocationRequestModelValidator locationModelValidator,
			IBOLLocationMapper BOLlocationMapper,
			IDALLocationMapper DALlocationMapper)
			: base(logger, locationRepository,
			       locationModelValidator,
			       BOLlocationMapper,
			       DALlocationMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>7e3bc3bafcca38031926607754b158b4</Hash>
</Codenesium>*/