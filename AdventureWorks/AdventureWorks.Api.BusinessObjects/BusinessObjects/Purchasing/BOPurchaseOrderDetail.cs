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
			IApiPurchaseOrderDetailModelValidator purchaseOrderDetailModelValidator)
			: base(logger, purchaseOrderDetailRepository, purchaseOrderDetailModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>8354cdf5b5f3b498632921bd516a10bf</Hash>
</Codenesium>*/