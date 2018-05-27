using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class PurchaseOrderDetailRepository: AbstractPurchaseOrderDetailRepository, IPurchaseOrderDetailRepository
	{
		public PurchaseOrderDetailRepository(
			IDALPurchaseOrderDetailMapper mapper,
			ILogger<PurchaseOrderDetailRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>4a13238206fba68741fbf2f17c0689c2</Hash>
</Codenesium>*/