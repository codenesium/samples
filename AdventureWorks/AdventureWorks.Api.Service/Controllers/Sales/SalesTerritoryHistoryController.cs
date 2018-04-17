using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/salesTerritoryHistories")]
	[ApiVersion("1.0")]
	public class SalesTerritoryHistoryController: AbstractSalesTerritoryHistoryController
	{
		public SalesTerritoryHistoryController(
			ILogger<SalesTerritoryHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesTerritoryHistory salesTerritoryHistoryManager
			)
			: base(logger,
			       transactionCoordinator,
			       salesTerritoryHistoryManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>10a327f1c474e1eaa9321852f7b927d7</Hash>
</Codenesium>*/