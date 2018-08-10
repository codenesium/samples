using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>c129dba4ba03d8cfa08e2ac2157ed4bc</Hash>
</Codenesium>*/