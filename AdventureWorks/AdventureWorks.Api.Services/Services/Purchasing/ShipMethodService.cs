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
    <Hash>6ba80bee01590e0ff03b87bb18daa694</Hash>
</Codenesium>*/