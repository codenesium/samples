using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class PurchaseOrderDetailRepository: AbstractPurchaseOrderDetailRepository, IPurchaseOrderDetailRepository
	{
		public PurchaseOrderDetailRepository(
			ILogger<PurchaseOrderDetailRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>9bb7f89c32c3ad0b921352703228f1c8</Hash>
</Codenesium>*/