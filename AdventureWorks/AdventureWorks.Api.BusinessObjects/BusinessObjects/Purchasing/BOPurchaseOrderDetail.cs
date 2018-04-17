using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOPurchaseOrderDetail: AbstractBOPurchaseOrderDetail, IBOPurchaseOrderDetail
	{
		public BOPurchaseOrderDetail(
			ILogger<PurchaseOrderDetailRepository> logger,
			IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
			IPurchaseOrderDetailModelValidator purchaseOrderDetailModelValidator)
			: base(logger, purchaseOrderDetailRepository, purchaseOrderDetailModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>b5f667b8d53ba4a4e4140924f519dfb8</Hash>
</Codenesium>*/