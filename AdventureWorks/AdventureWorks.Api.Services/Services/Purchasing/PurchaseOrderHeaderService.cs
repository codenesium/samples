using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class PurchaseOrderHeaderService : AbstractPurchaseOrderHeaderService, IPurchaseOrderHeaderService
	{
		public PurchaseOrderHeaderService(
			ILogger<IPurchaseOrderHeaderRepository> logger,
			IMediator mediator,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IApiPurchaseOrderHeaderServerRequestModelValidator purchaseOrderHeaderModelValidator,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper)
			: base(logger,
			       mediator,
			       purchaseOrderHeaderRepository,
			       purchaseOrderHeaderModelValidator,
			       dalPurchaseOrderHeaderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8f0360695f91d8bdd11c693dedfc639f</Hash>
</Codenesium>*/