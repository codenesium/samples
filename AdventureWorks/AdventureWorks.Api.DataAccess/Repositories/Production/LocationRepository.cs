using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class LocationRepository: AbstractLocationRepository, ILocationRepository
	{
		public LocationRepository(
			ILogger<LocationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>e7df52cce6a9ff7707555ff68ff8ad0e</Hash>
</Codenesium>*/