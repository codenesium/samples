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
    <Hash>f43cb64cd06802a3b023bdc7ed7e1fd2</Hash>
</Codenesium>*/