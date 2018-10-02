using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
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
    <Hash>30e2cefa67f2539efb1ac4b874215427</Hash>
</Codenesium>*/