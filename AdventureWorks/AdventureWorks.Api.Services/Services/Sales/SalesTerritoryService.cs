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
	public class SalesTerritoryService: AbstractSalesTerritoryService, ISalesTerritoryService
	{
		public SalesTerritoryService(
			ILogger<SalesTerritoryRepository> logger,
			ISalesTerritoryRepository salesTerritoryRepository,
			IApiSalesTerritoryRequestModelValidator salesTerritoryModelValidator,
			IBOLSalesTerritoryMapper BOLsalesTerritoryMapper,
			IDALSalesTerritoryMapper DALsalesTerritoryMapper)
			: base(logger, salesTerritoryRepository,
			       salesTerritoryModelValidator,
			       BOLsalesTerritoryMapper,
			       DALsalesTerritoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>6f9c50abe29cb57bbfd06a144b032cb4</Hash>
</Codenesium>*/