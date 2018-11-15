using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ShipMethodService : AbstractShipMethodService, IShipMethodService
	{
		public ShipMethodService(
			ILogger<IShipMethodRepository> logger,
			IShipMethodRepository shipMethodRepository,
			IApiShipMethodServerRequestModelValidator shipMethodModelValidator,
			IBOLShipMethodMapper bolShipMethodMapper,
			IDALShipMethodMapper dalShipMethodMapper,
			IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper)
			: base(logger,
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
    <Hash>d17529098c0e87576cf8ceb72e982166</Hash>
</Codenesium>*/