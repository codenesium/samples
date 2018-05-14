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
			IApiPurchaseOrderHeaderModelValidator purchaseOrderHeaderModelValidator)
			: base(logger, purchaseOrderHeaderRepository, purchaseOrderHeaderModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>afc6a7c21f12b1fa67d9e7f169e371dc</Hash>
</Codenesium>*/