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
	public class BOPurchaseOrderHeader: AbstractBOPurchaseOrderHeader, IBOPurchaseOrderHeader
	{
		public BOPurchaseOrderHeader(
			ILogger<PurchaseOrderHeaderRepository> logger,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IApiPurchaseOrderHeaderRequestModelValidator purchaseOrderHeaderModelValidator,
			IBOLPurchaseOrderHeaderMapper purchaseOrderHeaderMapper)
			: base(logger, purchaseOrderHeaderRepository, purchaseOrderHeaderModelValidator, purchaseOrderHeaderMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>dadfcde46e143579b66711bddc98958a</Hash>
</Codenesium>*/