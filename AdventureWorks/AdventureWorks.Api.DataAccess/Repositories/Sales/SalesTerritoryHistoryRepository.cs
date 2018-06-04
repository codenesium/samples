using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class SalesTerritoryHistoryRepository: AbstractSalesTerritoryHistoryRepository, ISalesTerritoryHistoryRepository
	{
		public SalesTerritoryHistoryRepository(
			ILogger<SalesTerritoryHistoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>69857eb945e475c074985c331b1758d1</Hash>
</Codenesium>*/