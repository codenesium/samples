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
	public partial class PurchaseOrderDetailRepository : AbstractPurchaseOrderDetailRepository, IPurchaseOrderDetailRepository
	{
		public PurchaseOrderDetailRepository(
			ILogger<PurchaseOrderDetailRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>455422bc5ebd0e265e23c3fb44a3d967</Hash>
</Codenesium>*/