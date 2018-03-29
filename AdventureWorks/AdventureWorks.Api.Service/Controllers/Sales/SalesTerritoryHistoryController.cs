using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	[Route("api/salesTerritoryHistories")]
	public class SalesTerritoryHistoriesController: AbstractSalesTerritoryHistoriesController
	{
		public SalesTerritoryHistoriesController(
			ILogger<SalesTerritoryHistoriesController> logger,
			ApplicationContext context,
			ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
			ISalesTerritoryHistoryModelValidator salesTerritoryHistoryModelValidator
			) : base(logger,
			         context,
			         salesTerritoryHistoryRepository,
			         salesTerritoryHistoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ff25b2eda9489be5cc1a443bff0bc6dc</Hash>
</Codenesium>*/