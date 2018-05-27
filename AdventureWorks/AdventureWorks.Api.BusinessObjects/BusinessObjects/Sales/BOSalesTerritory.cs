using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOSalesTerritory: AbstractBOSalesTerritory, IBOSalesTerritory
	{
		public BOSalesTerritory(
			ILogger<SalesTerritoryRepository> logger,
			ISalesTerritoryRepository salesTerritoryRepository,
			IApiSalesTerritoryRequestModelValidator salesTerritoryModelValidator,
			IBOLSalesTerritoryMapper salesTerritoryMapper)
			: base(logger, salesTerritoryRepository, salesTerritoryModelValidator, salesTerritoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>8c656ee6fba5140c3206f85c1837efde</Hash>
</Codenesium>*/