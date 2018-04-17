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
			ISalesTerritoryHistoryModelValidator salesTerritoryHistoryModelValidator)
			: base(logger, salesTerritoryHistoryRepository, salesTerritoryHistoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>64ad67ea8da404b5dc89924f9260cda7</Hash>
</Codenesium>*/