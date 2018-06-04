using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class PurchaseOrderHeaderRepository: AbstractPurchaseOrderHeaderRepository, IPurchaseOrderHeaderRepository
	{
		public PurchaseOrderHeaderRepository(
			ILogger<PurchaseOrderHeaderRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>e9b499c713e743f4f9ae5c5cbb6b0816</Hash>
</Codenesium>*/