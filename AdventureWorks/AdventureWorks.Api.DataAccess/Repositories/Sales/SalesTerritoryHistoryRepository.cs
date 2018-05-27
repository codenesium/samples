using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class SalesTerritoryHistoryRepository: AbstractSalesTerritoryHistoryRepository, ISalesTerritoryHistoryRepository
	{
		public SalesTerritoryHistoryRepository(
			IDALSalesTerritoryHistoryMapper mapper,
			ILogger<SalesTerritoryHistoryRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>b1c2d1ff4e8ce7d175778c35b9f8f110</Hash>
</Codenesium>*/