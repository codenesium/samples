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
	public partial class PurchaseOrderDetailService : AbstractPurchaseOrderDetailService, IPurchaseOrderDetailService
	{
		public PurchaseOrderDetailService(
			ILogger<IPurchaseOrderDetailRepository> logger,
			IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
			IApiPurchaseOrderDetailRequestModelValidator purchaseOrderDetailModelValidator,
			IBOLPurchaseOrderDetailMapper bolpurchaseOrderDetailMapper,
			IDALPurchaseOrderDetailMapper dalpurchaseOrderDetailMapper
			)
			: base(logger,
			       purchaseOrderDetailRepository,
			       purchaseOrderDetailModelValidator,
			       bolpurchaseOrderDetailMapper,
			       dalpurchaseOrderDetailMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>dcf5ce104f66ca0736d42bb875504a6a</Hash>
</Codenesium>*/