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
    <Hash>b4b623236ec91ff55fb521f325915dae</Hash>
</Codenesium>*/