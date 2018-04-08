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
			ITransactionCoordinator transactionCoordinator,
			ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
			ISalesTerritoryHistoryModelValidator salesTerritoryHistoryModelValidator
			) : base(logger,
			         transactionCoordinator,
			         salesTerritoryHistoryRepository,
			         salesTerritoryHistoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>89f9d64c0dcd4c462b488737c95fd6c6</Hash>
</Codenesium>*/