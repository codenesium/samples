using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>17e64b71efc5d32ef9c7d7d25d912cc6</Hash>
</Codenesium>*/