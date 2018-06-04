using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class SalesTerritoryRepository: AbstractSalesTerritoryRepository, ISalesTerritoryRepository
	{
		public SalesTerritoryRepository(
			ILogger<SalesTerritoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>3a8d13b9b7facbaf7a6e369aa4ac5404</Hash>
</Codenesium>*/