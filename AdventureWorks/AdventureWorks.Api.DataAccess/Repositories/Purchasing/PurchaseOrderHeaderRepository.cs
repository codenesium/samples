using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class PurchaseOrderHeaderRepository : AbstractPurchaseOrderHeaderRepository, IPurchaseOrderHeaderRepository
	{
		public PurchaseOrderHeaderRepository(
			ILogger<PurchaseOrderHeaderRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b438f3ca603244675794439a68799402</Hash>
</Codenesium>*/