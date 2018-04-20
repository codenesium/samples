using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/salesTerritoryHistories")]
	[ApiVersion("1.0")]
	[Response]
	public class SalesTerritoryHistoryController: AbstractSalesTerritoryHistoryController
	{
		public SalesTerritoryHistoryController(
			ServiceSettings settings,
			ILogger<SalesTerritoryHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesTerritoryHistory salesTerritoryHistoryManager
			)
			: base(settings,
			       logger,
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
    <Hash>d8aeca528c83a75ac390a0613c7bd1f3</Hash>
</Codenesium>*/