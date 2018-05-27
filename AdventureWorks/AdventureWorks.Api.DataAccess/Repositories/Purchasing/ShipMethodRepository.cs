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
	public class ShipMethodRepository: AbstractShipMethodRepository, IShipMethodRepository
	{
		public ShipMethodRepository(
			IDALShipMethodMapper mapper,
			ILogger<ShipMethodRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>3d23d0320d37c4d0cdc985a381f81a19</Hash>
</Codenesium>*/