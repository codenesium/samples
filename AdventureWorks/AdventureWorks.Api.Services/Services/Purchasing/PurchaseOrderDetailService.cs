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
	public partial class PurchaseOrderDetailService : AbstractPurchaseOrderDetailService, IPurchaseOrderDetailService
	{
		public PurchaseOrderDetailService(
			ILogger<IPurchaseOrderDetailRepository> logger,
			IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
			IApiPurchaseOrderDetailRequestModelValidator purchaseOrderDetailModelValidator,
			IBOLPurchaseOrderDetailMapper bolpurchaseOrderDetailMapper,
			IDALPurchaseOrderDetailMapper dalpurchaseOrderDetailMapper)
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
    <Hash>43336092a06f2ef4e5b0cb6149a47a48</Hash>
</Codenesium>*/