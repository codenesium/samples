using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class LocationRepository: AbstractLocationRepository, ILocationRepository
	{
		public LocationRepository(
			IDALLocationMapper mapper,
			ILogger<LocationRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>adeba0ed963f8631f95792e7e76810a3</Hash>
</Codenesium>*/