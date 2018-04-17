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
			ISalesTerritoryModelValidator salesTerritoryModelValidator)
			: base(logger, salesTerritoryRepository, salesTerritoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>47e62f05360a4330ae0a8d73df8287cd</Hash>
</Codenesium>*/