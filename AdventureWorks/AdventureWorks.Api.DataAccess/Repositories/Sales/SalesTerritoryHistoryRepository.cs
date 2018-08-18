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
    <Hash>8a930b0659114320d9f775cf0d3da4c7</Hash>
</Codenesium>*/