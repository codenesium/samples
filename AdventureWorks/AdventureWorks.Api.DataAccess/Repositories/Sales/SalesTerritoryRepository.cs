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
    <Hash>dc7c6bf5a607c06232d364e80839e568</Hash>
</Codenesium>*/