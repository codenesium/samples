using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class SalesTerritoryHistoryService: AbstractSalesTerritoryHistoryService, ISalesTerritoryHistoryService
	{
		public SalesTerritoryHistoryService(
			ILogger<SalesTerritoryHistoryRepository> logger,
			ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
			IApiSalesTerritoryHistoryRequestModelValidator salesTerritoryHistoryModelValidator,
			IBOLSalesTerritoryHistoryMapper BOLsalesTerritoryHistoryMapper,
			IDALSalesTerritoryHistoryMapper DALsalesTerritoryHistoryMapper)
			: base(logger, salesTerritoryHistoryRepository,
			       salesTerritoryHistoryModelValidator,
			       BOLsalesTerritoryHistoryMapper,
			       DALsalesTerritoryHistoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>b3c808a0acb2dc62c9b52f6f877e8cd7</Hash>
</Codenesium>*/