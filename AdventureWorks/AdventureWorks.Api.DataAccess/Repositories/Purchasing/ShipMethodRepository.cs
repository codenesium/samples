using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ShipMethodRepository: AbstractShipMethodRepository, IShipMethodRepository
	{
		public ShipMethodRepository(
			ILogger<ShipMethodRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>465fa2c91130e0ba81293e7a56f43067</Hash>
</Codenesium>*/