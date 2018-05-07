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
			IObjectMapper mapper,
			ILogger<LocationRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>90a41863ac55e80822241033ede3c624</Hash>
</Codenesium>*/