using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class PurchaseOrderHeaderService : AbstractPurchaseOrderHeaderService, IPurchaseOrderHeaderService
	{
		public PurchaseOrderHeaderService(
			ILogger<IPurchaseOrderHeaderRepository> logger,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IApiPurchaseOrderHeaderServerRequestModelValidator purchaseOrderHeaderModelValidator,
			IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper)
			: base(logger,
			       purchaseOrderHeaderRepository,
			       purchaseOrderHeaderModelValidator,
			       bolPurchaseOrderHeaderMapper,
			       dalPurchaseOrderHeaderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>dac37f0fabb57695aa0efb9799f86ad0</Hash>
</Codenesium>*/