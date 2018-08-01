using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ShipMethodRepository : AbstractShipMethodRepository, IShipMethodRepository
	{
		public ShipMethodRepository(
			ILogger<ShipMethodRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ce28ec9ec4c305a68be72bd088f51e64</Hash>
</Codenesium>*/