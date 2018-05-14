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
	public class BOSalesTerritoryHistory: AbstractBOSalesTerritoryHistory, IBOSalesTerritoryHistory
	{
		public BOSalesTerritoryHistory(
			ILogger<SalesTerritoryHistoryRepository> logger,
			ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
			IApiSalesTerritoryHistoryModelValidator salesTerritoryHistoryModelValidator)
			: base(logger, salesTerritoryHistoryRepository, salesTerritoryHistoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>879bd63fc997f6d870beddf6d28eae19</Hash>
</Codenesium>*/