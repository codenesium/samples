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
	public partial class PurchaseOrderHeaderService : AbstractPurchaseOrderHeaderService, IPurchaseOrderHeaderService
	{
		public PurchaseOrderHeaderService(
			ILogger<IPurchaseOrderHeaderRepository> logger,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IApiPurchaseOrderHeaderRequestModelValidator purchaseOrderHeaderModelValidator,
			IBOLPurchaseOrderHeaderMapper bolpurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalpurchaseOrderHeaderMapper,
			IBOLPurchaseOrderDetailMapper bolPurchaseOrderDetailMapper,
			IDALPurchaseOrderDetailMapper dalPurchaseOrderDetailMapper)
			: base(logger,
			       purchaseOrderHeaderRepository,
			       purchaseOrderHeaderModelValidator,
			       bolpurchaseOrderHeaderMapper,
			       dalpurchaseOrderHeaderMapper,
			       bolPurchaseOrderDetailMapper,
			       dalPurchaseOrderDetailMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2e5491de7e2a5c945a787a100eb47e6e</Hash>
</Codenesium>*/