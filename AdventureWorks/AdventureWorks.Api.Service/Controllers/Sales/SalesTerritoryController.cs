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
	[Route("api/salesTerritories")]
	[ApiVersion("1.0")]
	public class SalesTerritoryController: AbstractSalesTerritoryController
	{
		public SalesTerritoryController(
			ServiceSettings settings,
			ILogger<SalesTerritoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesTerritory salesTerritoryManager
			)
			: base(settings,
			       logger,
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
    <Hash>d8b0c4613653bab43d26432285651b13</Hash>
</Codenesium>*/