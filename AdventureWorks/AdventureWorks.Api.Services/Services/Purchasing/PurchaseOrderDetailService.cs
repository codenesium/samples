using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class PurchaseOrderDetailService: AbstractPurchaseOrderDetailService, IPurchaseOrderDetailService
	{
		public PurchaseOrderDetailService(
			ILogger<PurchaseOrderDetailRepository> logger,
			IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
			IApiPurchaseOrderDetailRequestModelValidator purchaseOrderDetailModelValidator,
			IBOLPurchaseOrderDetailMapper BOLpurchaseOrderDetailMapper,
			IDALPurchaseOrderDetailMapper DALpurchaseOrderDetailMapper)
			: base(logger, purchaseOrderDetailRepository,
			       purchaseOrderDetailModelValidator,
			       BOLpurchaseOrderDetailMapper,
			       DALpurchaseOrderDetailMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>ee049fb3b48b36e12f26d1cd0c6d8895</Hash>
</Codenesium>*/