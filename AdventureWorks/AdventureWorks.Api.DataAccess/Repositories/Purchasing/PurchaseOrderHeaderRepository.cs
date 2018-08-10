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
    <Hash>11d23f8e472cd11dc1d305e871ae601d</Hash>
</Codenesium>*/