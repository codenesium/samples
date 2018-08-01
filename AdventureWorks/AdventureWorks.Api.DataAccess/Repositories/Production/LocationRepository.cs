using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class LocationRepository : AbstractLocationRepository, ILocationRepository
	{
		public LocationRepository(
			ILogger<LocationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7e2fec1c5141357aa0f28fd6b39ac71d</Hash>
</Codenesium>*/