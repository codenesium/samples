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
			IApiSalesTerritoryModelValidator salesTerritoryModelValidator)
			: base(logger, salesTerritoryRepository, salesTerritoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>e3e7648f0adc38f520073c39718636e5</Hash>
</Codenesium>*/