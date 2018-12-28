using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ShipMethodService : AbstractShipMethodService, IShipMethodService
	{
		public ShipMethodService(
			ILogger<IShipMethodRepository> logger,
			IMediator mediator,
			IShipMethodRepository shipMethodRepository,
			IApiShipMethodServerRequestModelValidator shipMethodModelValidator,
			IBOLShipMethodMapper bolShipMethodMapper,
			IDALShipMethodMapper dalShipMethodMapper,
			IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper)
			: base(logger,
			       mediator,
			       shipMethodRepository,
			       shipMethodModelValidator,
			       bolShipMethodMapper,
			       dalShipMethodMapper,
			       bolPurchaseOrderHeaderMapper,
			       dalPurchaseOrderHeaderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ce7ceb72426cf6e0f80b022829f2ea58</Hash>
</Codenesium>*/