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
    <Hash>7a9c558ce6359de1557ab1a8728d11c3</Hash>
</Codenesium>*/