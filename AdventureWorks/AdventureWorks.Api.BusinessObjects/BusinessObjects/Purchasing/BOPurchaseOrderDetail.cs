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
			IApiPurchaseOrderDetailRequestModelValidator purchaseOrderDetailModelValidator,
			IBOLPurchaseOrderDetailMapper purchaseOrderDetailMapper)
			: base(logger, purchaseOrderDetailRepository, purchaseOrderDetailModelValidator, purchaseOrderDetailMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>e67467a5d7c6d7181fb9fc688eb7a530</Hash>
</Codenesium>*/