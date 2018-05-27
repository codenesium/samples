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
			IApiSalesTerritoryHistoryRequestModelValidator salesTerritoryHistoryModelValidator,
			IBOLSalesTerritoryHistoryMapper salesTerritoryHistoryMapper)
			: base(logger, salesTerritoryHistoryRepository, salesTerritoryHistoryModelValidator, salesTerritoryHistoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>becb862ecd28bac9e629a72037eea3c7</Hash>
</Codenesium>*/