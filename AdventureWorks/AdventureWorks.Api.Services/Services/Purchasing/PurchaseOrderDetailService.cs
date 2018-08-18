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
    <Hash>a362c8f8aca1dc91f814b3e570cb3a60</Hash>
</Codenesium>*/