using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ShipMethodService : AbstractShipMethodService, IShipMethodService
	{
		public ShipMethodService(
			ILogger<IShipMethodRepository> logger,
			IShipMethodRepository shipMethodRepository,
			IApiShipMethodRequestModelValidator shipMethodModelValidator,
			IBOLShipMethodMapper bolshipMethodMapper,
			IDALShipMethodMapper dalshipMethodMapper,
			IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper
			)
			: base(logger,
			       shipMethodRepository,
			       shipMethodModelValidator,
			       bolshipMethodMapper,
			       dalshipMethodMapper,
			       bolPurchaseOrderHeaderMapper,
			       dalPurchaseOrderHeaderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ef086ae1d88a4db54c8a7b8f8d8c8229</Hash>
</Codenesium>*/