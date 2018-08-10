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
	public partial class SalesTerritoryRepository : AbstractSalesTerritoryRepository, ISalesTerritoryRepository
	{
		public SalesTerritoryRepository(
			ILogger<SalesTerritoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ae44a3c6a881cb4d405b8245709e4616</Hash>
</Codenesium>*/