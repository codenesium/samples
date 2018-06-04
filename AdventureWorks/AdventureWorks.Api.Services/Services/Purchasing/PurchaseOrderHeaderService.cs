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
	public class PurchaseOrderHeaderService: AbstractPurchaseOrderHeaderService, IPurchaseOrderHeaderService
	{
		public PurchaseOrderHeaderService(
			ILogger<PurchaseOrderHeaderRepository> logger,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IApiPurchaseOrderHeaderRequestModelValidator purchaseOrderHeaderModelValidator,
			IBOLPurchaseOrderHeaderMapper BOLpurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper DALpurchaseOrderHeaderMapper)
			: base(logger, purchaseOrderHeaderRepository,
			       purchaseOrderHeaderModelValidator,
			       BOLpurchaseOrderHeaderMapper,
			       DALpurchaseOrderHeaderMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>68c62742eea81572d70b79cf2062118c</Hash>
</Codenesium>*/