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
			IPurchaseOrderHeaderModelValidator purchaseOrderHeaderModelValidator)
			: base(logger, purchaseOrderHeaderRepository, purchaseOrderHeaderModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>9d3da26652cf00431396f759b551dca6</Hash>
</Codenesium>*/