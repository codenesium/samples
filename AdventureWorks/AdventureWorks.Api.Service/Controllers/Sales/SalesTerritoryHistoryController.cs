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
	public class SalesTerritoryHistoryController: AbstractSalesTerritoryHistoryController
	{
		public SalesTerritoryHistoryController(
			ILogger<SalesTerritoryHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
			ISalesTerritoryHistoryModelValidator salesTerritoryHistoryModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       salesTerritoryHistoryRepository,
			       salesTerritoryHistoryModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>cb218c915e366f8b829cad98f4ea234c</Hash>
</Codenesium>*/