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
	public partial class SalesTerritoryHistoryRepository : AbstractSalesTerritoryHistoryRepository, ISalesTerritoryHistoryRepository
	{
		public SalesTerritoryHistoryRepository(
			ILogger<SalesTerritoryHistoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>55c444d60b0744f85fab71b05ea0426c</Hash>
</Codenesium>*/