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
	[Route("api/salesTerritories")]
	[ApiVersion("1.0")]
	public class SalesTerritoryController: AbstractSalesTerritoryController
	{
		public SalesTerritoryController(
			ILogger<SalesTerritoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesTerritory salesTerritoryManager
			)
			: base(logger,
			       transactionCoordinator,
			       salesTerritoryManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c4c7971a3c6dd638ce71166a6f75db5d</Hash>
</Codenesium>*/